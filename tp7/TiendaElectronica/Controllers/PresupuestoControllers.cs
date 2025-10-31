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
    public IActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        _presupuestoRepository.CrearPresupuesto(presupuesto);
        return Created("Presupuesto dado de alta correctamente", presupuesto);
    }

    [HttpPost("ProductoDetalle")]
    public IActionResult AgregarAlPresupuesto(int id, int idProducto, int cantidadProducto)
    {
        var resultado = _presupuestoRepository.AgregarAlPresupuesto(id, idProducto, cantidadProducto);
        if (resultado == -1) return Conflict("El ID del producto o presupuesto no existe, no puedo agregarse al presupuesto");
        else if (resultado == 0) return Conflict("No pudo agregarse al presupuesto");
        return Created();
    }

    [HttpGet("PresupuestoDetalles/{id}")]
    public IActionResult GetDetallesById(int id)
    {
        var presupuesto = _presupuestoRepository.GetDetallesById(id);
        if (presupuesto == null) return NotFound($"No se encontró un producto con el ID {id}.");
        return Ok(presupuesto);
    }

    [HttpGet("PresupuestosExistentes")]
    public IActionResult GetAll()
    {
        var presupuestos = _presupuestoRepository.GetAll();
        return Ok(presupuestos);
    }
    
}