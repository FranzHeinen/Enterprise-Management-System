using EmpresaData;
using EmpresaDto;
using EmpresaService;
using System.Runtime.InteropServices;

namespace EmpresaTest
{
    public class CompraTest
    {
        public CompraService compraService { get; set; }
        public ClienteService clienteService { get; set; }
        [SetUp]
        public void Setup()
        {
            compraService = new CompraService();
            clienteService = new ClienteService();
        }
        [TearDown]
        public void Cleanup()
        {
            File.WriteAllText("Compras.json", "[]");
        }

        [Test]
        public void CargarCompra_OK()
        {
            ClienteDto clienteDto = new ClienteDto()
            {
                Dni = 1,
                Apellido = "Lopez",
                Email = "virtualbox@gmail",
                Latitud = -32.9575,
                Longitud = -60.639444444444,
                FechaNacimiento = new DateTime(2000, 10, 12),
                Nombre = "Juan",
                Telefono = 123456,
            };
            clienteService.CrearCliente(clienteDto);

            CompraDto compraDto1 = new CompraDto()
            {
                CodigoProducto = 1,
                DniCliente = 1,
                FechaEntrega = DateTime.Now,
                CantidadComprada = 20,
            };

            var res = compraService.CrearCompra(compraDto1);
            var nuevaCompra = CompraFiles.LeerComprasDesdeJson().FirstOrDefault(x => x.DniCliente == 1);
            var lista = CompraFiles.LeerComprasDesdeJson();

            Assert.IsTrue(res.Success);
            Assert.That(nuevaCompra.CantidadComprada, Is.EqualTo(20));
        }

    }
}