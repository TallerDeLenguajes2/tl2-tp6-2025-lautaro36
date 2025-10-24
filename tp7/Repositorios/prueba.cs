
public partial class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Iniciando prueba de conexion  y creacion de producto...");

        // 1. Instancia el repositorio
        var repositorio = new ProductoRepository(); 
        
        // 2. Crea un objeto de prueba
        var nuevoProducto = new Producto 
        {
            Descripcion = "Laptop de Prueba",
            Precio = 999,
            IdProducto = 10
        };

        try
        {
            // 3. Llama al método a probar
            repositorio.crearProducto(nuevoProducto);
            
            Console.WriteLine("Producto creado correctamente en la base de datos.");
        }
        catch (Exception ex)
        {
            // Si hay un error, lo verás aquí (mala cadena de conexión, tabla no existe, etc.)
            Console.WriteLine($"Error al crear el producto: {ex.Message}");
            Console.WriteLine($"Detalle del error: {ex.InnerException?.Message}");
        }
        
        Console.ReadKey();
    }
}