using EmpresaDto;
using EmpresaService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpresaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService Cliente { get; set; }

        public ClienteController()
        {
            Cliente = new ClienteService();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = Cliente.ObtenerListaClientes();
            return Ok(clientes);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            var cliente = Cliente.ObtenerClientePorDni(dni);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDto clienteDto)
        {
            var success = Cliente.CrearCliente(clienteDto);
            if (success == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{dni}")]
        public IActionResult Put(int dni, [FromBody] ClienteDto clienteDto)
        {
            var resultado = Cliente.EditarCliente(dni, clienteDto);


            return StatusCode(resultado.Codigo, resultado);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{dni}")]
        public IActionResult Delete(int dni)
        {
            var success = Cliente.EliminarCliente(dni);
            if (success == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
