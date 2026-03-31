using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexión a MariaDB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. Habilitar CORS para Next.js
builder.Services.AddCors(options => options.AddPolicy("Libre", policy => 
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseCors("Libre");

// --- RUTAS API ---

// LEER PRODUCTOS
app.MapGet("/api/productos", async (AppDbContext db) => 
    await db.Productos.ToListAsync());

// CREAR PRODUCTO (Blindado contra error de fecha)
app.MapPost("/api/productos", async (AppDbContext db, Producto nuevo) => {
    // Forzamos la fecha actual para evitar el error 500 de MariaDB
    nuevo.FechaRegistro = DateTime.Now;
    
    db.Productos.Add(nuevo);
    await db.SaveChangesAsync();
    return Results.Created($"/api/productos/{nuevo.Id}", nuevo);
});

// VENTA RÁPIDA
app.MapPost("/api/productos/{id}/vender", async (AppDbContext db, int id) => {
    var producto = await db.Productos.FindAsync(id);
    if (producto is null) return Results.NotFound();
    if (producto.Stock <= 0) return Results.BadRequest("Sin stock");

    producto.Stock -= 1;
    await db.SaveChangesAsync();
    return Results.Ok(new { nuevoStock = producto.Stock });
});

// ACTUALIZAR PRODUCTO
app.MapPut("/api/productos/{id}", async (AppDbContext db, int id, Producto actualizado) => {
    var producto = await db.Productos.FindAsync(id);
    if (producto is null) return Results.NotFound();

    producto.Nombre = actualizado.Nombre;
    producto.Precio = actualizado.Precio;
    producto.Stock = actualizado.Stock;
    // No tocamos la fecha de registro en las actualizaciones
    producto.ImagenUrl = actualizado.ImagenUrl;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ELIMINAR PRODUCTO
app.MapDelete("/api/productos/{id}", async (AppDbContext db, int id) => {
   var producto = await db.Productos.FindAsync(id);
   if (producto == null) return Results.NotFound();

   db.Productos.Remove(producto);
   await db.SaveChangesAsync();
   return Results.NoContent();
});

// RUTA DE LOGIN
app.MapPost("/api/auth/login", async (AppDbContext db, Usuario loginData) => {
    var usuario = await db.Usuarios
        .FirstOrDefaultAsync(u => u.Username == loginData.Username && u.Password == loginData.Password);

    if (usuario is null) return Results.Unauthorized();

    // Devolvemos el rol para que el Frontend sepa qué mostrar
    return Results.Ok(new { username = usuario.Username, rol = usuario.Rol });
});

// RUTA DE REGISTRO (Crear cuenta)
app.MapPost("/api/auth/register", async (AppDbContext db, Usuario nuevo) => {
    if (await db.Usuarios.AnyAsync(u => u.Username == nuevo.Username)) 
        return Results.BadRequest("El usuario ya existe");

    db.Usuarios.Add(nuevo);
    await db.SaveChangesAsync();
    return Results.Ok(new { mensaje = "Cuenta creada con éxito" });
});



app.Run();