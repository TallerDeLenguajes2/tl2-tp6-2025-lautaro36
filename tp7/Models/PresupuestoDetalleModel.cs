public class PresupuestoDetalle
{
    Producto producto;
    int cantidad;

    public Producto Producto { get => producto; set => producto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    
    public int GetPrecio ()
    {
        return producto.Precio;
    }
}