using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository _presupuestoRepository;

    public PresupuestoController()
    {
        _presupuestoRepository = new PresupuestoRepository();
    }

    [HttpPost("AltaPresupuesto")]
    public IActionResult CrearProducto(Presupuesto presupuesto)
    {
        _presupuestoRepository.CrearPresupuesto(presupuesto);
        return Created("Presupuesto dado de alta correctamente", presupuesto);
    }
}