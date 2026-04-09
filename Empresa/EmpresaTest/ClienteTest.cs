using EmpresaData;
using EmpresaDto;
using EmpresaService;
using System.Runtime.InteropServices;

namespace EmpresaTest
{
    public class ClienteTest
    {
        public ClienteService clienteService { get; set; }
        public ClienteDto clienteDto { get; set; }
        [SetUp]
        public void Setup()
        {
            clienteService = new ClienteService();
            clienteDto = new ClienteDto()
            {
                Dni = 11,
                Apellido = "Lopez",
                Email = "virtualbox@gmail",
                Latitud = -32.9575,
                Longitud = -60.639444444444,
                FechaNacimiento = new DateTime(2000, 10, 12),
                Nombre = "Juan",
                Telefono = 123456,
            };

        }
        [TearDown]
        public void Cleanup()
        {
            File.WriteAllText("Clientes.json", "[]");
        }

        [Test]
        public void CrearCliente_OK()
        {
            var res = clienteService.CrearCliente(clienteDto);

            var cliente = clienteService.ObtenerClientePorDni(11);

            Assert.That(cliente.Apellido, Is.EqualTo("Lopez"));
        }
        [Test]
        public void EditarCliente_OK()
        {
            ClienteDto willy = new ClienteDto()
            {
                Dni = 11,
                Apellido = "Williner",
                Email = "virtualbox@gmail",
                Latitud = -32.9575,
                Longitud = -60.639444444444,
                FechaNacimiento = new DateTime(2000, 10, 12),
                Nombre = "Felipe",
                Telefono = 123456,
            };

            clienteService.CrearCliente(clienteDto);
            var res = clienteService.EditarCliente(11, willy);
            var clienteModificado = clienteService.ObtenerClientePorDni(clienteDto.Dni);
            Assert.That(clienteModificado.Apellido, Is.EqualTo("Williner"));
            Assert.That(res.Success, Is.True);
        }
        [Test]
        public void EliminarCliente_OK()
        {
            var res = clienteService.CrearCliente(clienteDto);

            var eliminar = clienteService.EliminarCliente(11);

            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == 11);

            Assert.IsNotNull(cliente.FechaEliminacion);
        }

      
    }
}