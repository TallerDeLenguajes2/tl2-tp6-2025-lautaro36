using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository _productoRepository;
    public ProductoController()
    {
        _productoRepository = new ProductoRepository();
    }

    [HttpPost("")]
    public IActionResult crearProducto([FromBody] Producto producto)
    {
        _productoRepository.crearProducto(producto);
        return Created("producto/7", producto);
    }

    [HttpGet("")]
    public IActionResult GetAll()
    {
        var productos = _productoRepository.GetAll();
        return Ok(productos);
    }

    [HttpGet("id")]
    public IActionResult GetDetallesById([FromQuery] int id)
    {
        var producto = _productoRepository.GetDetallesByID(id);
        return Ok(producto);
    }

    // [HttpDelete("")]
    // public IActionResult BorrarProducto(int id)
    // {
    //     _productoRepository.DeleteByID(id);
    //     return Ok();
    // }

}