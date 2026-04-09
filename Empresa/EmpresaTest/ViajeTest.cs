using EmpresaData;
using EmpresaDto;
using EmpresaEntities;
using EmpresaService;

namespace EmpresaTest
{
    public class ViajeTest
    {
        public ViajeService viajeService { get; set; }
        [SetUp]
        public void Setup()
        {
            viajeService = new ViajeService();

            Camioneta camioneta1 = new Camioneta();
            camioneta1.Tipo = "Doble Cabina";
            camioneta1.Patente = "AA0030AD";
            camioneta1.TamañoCargaCm3 = 3300.0;
            camioneta1.DistanciaMaxKm = 350.0;
            CamionetaFiles.EscribirCamionetasAJson(camioneta1);
            Camioneta camioneta2 = new Camioneta();
            camioneta2.Tipo = "Simple";
            camioneta2.Patente = "AC123ADC";
            CamionetaFiles.EscribirCamionetasAJson(camioneta2);
            Viaje viaje = new Viaje();
            viaje.FechaEntregaPosibleDesde = new DateTime(2025, 11, 9);
            viaje.FechaEntregaPosibleHasta = new DateTime(2025, 11, 16);
            viaje.PatenteCamionetaAsignada = camioneta2.Patente;
            ViajeFiles.EscribirViajesAJson(viaje);
        }

        [Test]
        public void CalcularDistancia_OK()
        {
            Compra compra = new Compra()
            {
                Codigo = 1,
                FechaActualizacion = DateTime.Now,
                CodigoProducto = 1,
                DniCliente = 444444,
                FechaCompra = DateTime.Today,
                Estado = EnumTipoCompra.Ready_To_Dispatch,
                FechaEliminacion = null,
                FechaEntrega = DateTime.Now,
                Latitud = -32.9575,
                Longitud = -60.639444444444,
                MontoTotal = 150000,
                CantidadComprada = 20,
            };
            var res = viajeService.CalcularDistancia(compra);

            Assert.That(res, Is.EqualTo(206.09666267321265));
        }
        [Test]
        public void CargarViaje_OK()
        {
            ViajeDto viajeDto = new ViajeDto()
            {
                FechaDesde = new DateTime(2025, 11, 10),
                FechaHasta = new DateTime(2025, 11, 15),
            };
            var viaje = viajeService.GestionarViaje(viajeDto);

            Assert.That(viaje.Codigo, Is.EqualTo(200));
        }
        [Test]
        public void BuscarCamioneta_Ok()
        {
            ViajeDto viajeDto = new ViajeDto()
            {
                FechaDesde = new DateTime(2025, 11, 10),
                FechaHasta = new DateTime(2025, 11, 15),
            };
            var camioneta = viajeService.BuscarCamionetaDisponible(viajeDto);

            Assert.That(camioneta.Patente, Is.EqualTo(camioneta.Patente));

        }

        [TearDown]
        public void Cleanup()
        {
            // Limpia el archivo JSON al final de cada test
            File.WriteAllText("Camionetas.json", "[]");
            File.WriteAllText("Viajes.json", "[]");
        }
    }
}