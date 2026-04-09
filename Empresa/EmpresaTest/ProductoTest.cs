using EmpresaData;
using EmpresaDto;
using EmpresaService;
using System.Runtime.InteropServices;

namespace EmpresaTest
{
    public class ProductoTest
    {
        public ProductoService productoService { get; set; }
        [SetUp]
        public void Setup()
        {
            productoService = new ProductoService(); ;
        }

        [Test]
        public void CargarProducto_OK()
        {
            ProductoDto productoDto1 = new ProductoDto()
            {
                Nombre = "Caja",
                CantidadStock = 100,
                AltoCajaCm = 100,
                AnchoCajaCm = 100,
                ProfundidadCajaCm = 100,
                Marca = "Trucho",
                PrecioUnitario = 1000,
                StockMinimo = 10,
            };

            var res = productoService.AgregarProducto(productoDto1);
            var lista = ProductoFiles.LeerProductosDesdeJson();

            Assert.IsTrue(res);
        }
        [Test]
        public void EditarStock_OK()
        {
            var res = productoService.EditarStock(100, 1);

            Assert.IsTrue(res);
        }
    }
}