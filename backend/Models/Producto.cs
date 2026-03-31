using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    // ✅ FECHA AUTOMÁTICA: Esto evita el error de fecha inválida (0001-01-01)
    [Column("fecha_registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string? ImagenUrl { get; set; }
}