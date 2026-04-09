using EmpresaDto;
using EmpresaEntities;
using EmpresaService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpresaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoService Producto { get; set; }
        public ProductoController()
        {
            Producto = new ProductoService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var productos = Producto.ObtenerProductosStockMinimo();
            return Ok(productos);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Producto.AgregarProducto(productoDto);
            return Ok();

        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}/{cantidad}")]
        public IActionResult Put(int id, int cantidad)
        {
            var success = Producto.EditarStock(cantidad, id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}
