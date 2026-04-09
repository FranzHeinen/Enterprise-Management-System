using EmpresaDto;
using EmpresaEntities;
using EmpresaService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpresaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private CompraService Compra { get; set; }
        public CompraController()
        {
            Compra = new CompraService();
        }
        // POST api/<CompraController>
        [HttpPost]
        public IActionResult Post([FromBody] CompraDto compraDto)
        {
            var resultado = Compra.CrearCompra(compraDto);
            return StatusCode(resultado.Codigo, resultado);
        }


    }
}
