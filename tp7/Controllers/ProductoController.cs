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

    [HttpPost("")]// preguntar que va aca
    public IActionResult crearProducto([FromBody] Producto producto)
    {
        _productoRepository.crearProducto(producto);
        return Created("producto", producto);
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
        if(producto == null) return NotFound($"No se encontró un producto con el ID {id}.");    
        return Ok(producto);
    }

    [HttpDelete]
    public IActionResult BorrarProducto([FromQuery] int id)
    {
        var borradoCorrecto = _productoRepository.DeleteByID(id);
        if (borradoCorrecto == -1) return BadRequest("El producto ya fue agregado a uno o mas presupuestos, asegurese de borrar primero el/los presupuestos.");
        else if(borradoCorrecto == 0) return NotFound($"No se encontró un producto con el ID {id}.");
        return Ok();
    } //no funciona si intento borrar un producto que se encuentra sienndo referenciado en otra tabla. 
    // FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto) ON DELETE CASCADE
    //tambien puedo borrar primero las dependencias o verificar si una tabla esta referenciando el producto

}