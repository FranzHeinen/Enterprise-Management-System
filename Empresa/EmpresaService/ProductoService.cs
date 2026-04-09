
using EmpresaData;
using EmpresaDto;
using EmpresaEntities;

namespace EmpresaService
{
    public class ProductoService
    {
        public List<Producto> ObtenerProductosStockMinimo()
        {
            return ProductoFiles.LeerProductosDesdeJson().FindAll(x => x.StockMinimo > x.CantidadStock);
        }
        public bool AgregarProducto(ProductoDto productoDto)
        {
            if (productoDto == null) { return false; }
            var producto = ConvertirAProducto(productoDto);
            producto.FechaCreacion = DateTime.Now;
            ProductoFiles.EscribirProductosAJson(producto);
            return true;
        }
        public bool EditarStock(int cantidadStock, int id)
        {
            var producto = ProductoFiles.LeerProductosDesdeJson().FirstOrDefault(x => x.CodigoUnico == id);
            if (producto == null) { return false; }
            producto.CantidadStock += cantidadStock;
            producto.FechaActualizacion = DateTime.Now;
            ProductoFiles.EscribirProductosAJson(producto);
            return true;

        }

        private Producto ConvertirAProducto(ProductoDto productoDto)
        {
            Producto producto = new Producto();
            producto.Nombre = productoDto.Nombre;
            producto.Marca = productoDto.Marca;
            producto.AltoCajaCm = productoDto.AltoCajaCm;
            producto.AnchoCajaCm = productoDto.AnchoCajaCm;
            producto.ProfundidadCajaCm = productoDto.ProfundidadCajaCm;
            producto.PrecioUnitario = productoDto.PrecioUnitario;
            producto.StockMinimo = productoDto.StockMinimo;
            producto.CantidadStock = productoDto.CantidadStock;

            return producto;
        }
    }
}
