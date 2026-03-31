# 🏍️ Sullana Motos PRO - Landing Page v1.0

Este proyecto es una **Landing Page de alto rendimiento** diseñada específicamente para talleres mecánicos y tiendas de repuestos en Sullana, Piura. Enfocada en la experiencia de usuario (UX) y la conversión directa mediante canales digitales.

---

## 🚀 Funcionalidades Principales

### 🔍 1. Catálogo de Repuestos Dinámico
- **Integración con API Real:** Consumo de datos desde el backend local (`ASP.NET Core / C#`).
- **Búsqueda Predictiva:** Implementación de `useMemo` para filtrado instantáneo en el cliente, optimizando el rendimiento y evitando renders innecesarios.
- **Grilla Interactiva:** Visualización de productos con miniaturas que se activan dinámicamente al buscar.

### 🖼️ 2. Modal de Detalles "Tuned"
- **Efecto de Enfoque:** Implementación de `backdrop-blur-md` para aislar el producto y mejorar la atención del cliente.
- **Animaciones Pro:** Entrada suave con efecto de zoom escalado (`animate-modal`) y transiciones de opacidad.
- **WhatsApp Directo:** Botón de acción que genera un mensaje automático incluyendo el nombre del producto, precio y consulta de stock.

### 📅 3. Sistema de Agendamiento Inteligente
- **Captura de Citas:** Interfaz para selección de fecha y hora integrada en la tarjeta de mantenimiento.
- **Lógica de Validación:** Bloqueo automático de fechas pasadas mediante atributos dinámicos en el cliente (`min date`).
- **Tickets de Servicio:** Generación de mensajes estructurados para WhatsApp con los datos de la cita listos para confirmar.

### 📍 4. Ubicación con Modo Oscuro (Hack CSS)
- **Mapa Interactivo:** Integración de Google Maps mediante Iframe.
- **Estética Dark:** Aplicación de filtros avanzados (`invert`, `grayscale`, `contrast`) para integrar el mapa estándar con la estética oscura y naranja de la marca.
- **Deep Linking:** Configurado para abrir rutas de navegación automáticas en dispositivos móviles.

---

## 🛠️ Stack Tecnológico

- **Framework:** [Next.js 15](https://nextjs.org/) (App Router)
- **Lenguaje:** [TypeScript](https://www.typescriptlang.org/) (Tipado estricto sin errores de ESLint)
- **Estilos:** [Tailwind CSS](https://tailwindcss.com/) (Arquitectura Dark Mode)
- **Iconografía:** [Lucide React](https://lucide.dev/)
- **Notificaciones:** [React Hot Toast](https://react-hot-toast.com/)

---

## 📦 Instalación y Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/tu-usuario/Enterprise-FullStack-Lab.git](https://github.com/tu-usuario/Enterprise-FullStack-Lab.git)
