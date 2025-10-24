public class Presupuesto
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateTime fechaCreacion;
    private List<PresupuestoDetalle> listadoDetalles;

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    public List<PresupuestoDetalle> Detalle { get => listadoDetalles; set => listadoDetalles = value; }

    public int MontoPresupuesto()
    {
        int resultado=0;
        foreach(var detalle in listadoDetalles)
        {
            resultado += detalle.Cantidad * detalle.GetPrecio();
        }
        return resultado;
    }
    public double  MontoPresupuestoConIva()
    {
        return MontoPresupuesto()*1.21;
    }
    public int CantidadProductos ()
    {
        int resultado=0;
        foreach(var detalle in listadoDetalles)
        {
            resultado += detalle.Cantidad;
        }
        return resultado;
    }
}