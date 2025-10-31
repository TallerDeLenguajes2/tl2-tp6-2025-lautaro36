using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TiendaElectronica.Repositorios;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository _productoRepository; //usando Ingterfaz para hacer pruebas unitarias en MOQ
    public ProductoController()
    {
        _productoRepository = new ProductoRepository(); //usando Ingterfaz para hacer pruebas unitarias en MOQ
    }

    [HttpPost("AltaProducto")]
    public IActionResult CrearProducto([FromBody] Producto producto)
    {
        int resultado = _productoRepository.CrearProducto(producto);
        if (resultado == 0) return Conflict("Problemas al dar de alta el producto.");
        return Created("producto dado de alta correctamente.", producto);
    }

    [HttpGet("Productos")]
    public IActionResult GetAll()
    {
        var productos = _productoRepository.GetAll();
        return Ok(productos);   
    }

    [HttpPut("{id}")]
    public IActionResult ModificarProducto([FromBody]Producto producto, int id)
    {
        var updateCorrecto = _productoRepository.ModificarProducto(id, producto);
        if (!updateCorrecto) return NotFound($"No se encontró un producto con el ID {id}.");
        return Ok();
    }

    [HttpGet("{id}")] // antes lo tenia como [HttpGet("id")] pero devolvia este url https://localhost:7235/Producto/id?id=4
    public IActionResult GetDetallesById(int id)
    {
        var producto = _productoRepository.GetDetallesByID(id);
        if(producto == null) return NotFound($"No se encontró un producto con el ID {id}.");    
        return Ok(producto);    
    }

    [HttpDelete("{id}")]
    public IActionResult BorrarProducto(int id)
    {
        var borradoCorrecto = _productoRepository.DeleteByID(id);
        if (borradoCorrecto == -1) return Conflict("El producto ya fue agregado a uno o mas presupuestos, asegurese de borrar primero el/los presupuestos.");//Bad Request implica que la solicitud HTTP en sí es incorrecta, conflict indica que la solicitud es válida, pero no puede hay un conflicto con el estado actual del recurso. es mas especifica
        else if (borradoCorrecto == 0) return NotFound($"No se encontró un producto con el ID {id}.");
        return NoContent();//noContent es la respuesta estándar para operaciones DELETE exitosas
    }
    //no funciona si intento borrar un producto que se encuentra sienndo referenciado en otra tabla. 
    // FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto) ON DELETE CASCADE
    //tambien puedo borrar primero las dependencias o verificar si una tabla esta referenciando el producto
    
    //result()

}