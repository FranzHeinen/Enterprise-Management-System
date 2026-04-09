using EmpresaDto;
using EmpresaService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpresaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private ViajeService Viaje { get; set; }
        public ViajeController()
        {
            Viaje = new ViajeService();
        }
        // POST api/<ViajeController>
        [HttpPost]
        public IActionResult Post(ViajeDto viajeDto)
        {
            var res = Viaje.GestionarViaje(viajeDto);

            return StatusCode(res.Codigo, res);
        }
    }
}
