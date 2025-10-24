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

    [HttpGet("products")]
    public IActionResult GetAll()
    {
        var productos = _productoRepository.GetAll();
        return Ok(productos);
    }

    [HttpPost("producto")]
    public IActionResult crearProducto([FromBody] Producto producto)
    {
        _productoRepository.crearProducto(producto);
        return Created("producto/7", producto);
    }



}