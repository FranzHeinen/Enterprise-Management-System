using EmpresaData;
using EmpresaDto;
using EmpresaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaService
{
    public class CompraService
    {

        public Resultado CrearCompra(CompraDto compraDto)
        {
            var producto = ProductoFiles.LeerProductosDesdeJson().FirstOrDefault(x => x.CodigoUnico == compraDto.CodigoProducto);
            if (producto == null) { return new Resultado() { Codigo = 404, Mensaje = "No se encontro el producto", Success = false }; }
            if (producto.CantidadStock < compraDto.CantidadComprada)
            {
                return new Resultado() { Codigo = 400, Mensaje = "Cantidad stock insuficiente.", Success = false };
            }
            producto.CantidadStock -= compraDto.CantidadComprada;
            ProductoFiles.EscribirProductosAJson(producto);

            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == compraDto.DniCliente);
            if (cliente == null) { return new Resultado() { Codigo = 404, Mensaje = "No se encontró el cliente", Success = false }; }

            var compra = ConvertirACompra(compraDto);
            compra.FechaCompra = DateTime.Now;
            compra.Estado = (EnumTipoCompra)0; 
            compra.Latitud = cliente.Latitud;
            compra.Longitud = cliente.Longitud;
            compra.MontoTotal = compra.CalcularMontoTotal(producto.PrecioUnitario);
            CompraFiles.EscribirComprasAJson(compra);
            return new Resultado() { Codigo = 200, Mensaje = "Compra creada con exito.", Success = true };
        }

        private Compra ConvertirACompra(CompraDto compraDto)
        {
            Compra compra = new Compra();
            compra.CodigoProducto = compraDto.CodigoProducto;
            compra.CantidadComprada = compraDto.CantidadComprada;
            compra.DniCliente = compraDto.DniCliente;
            compra.FechaEntrega = compraDto.FechaEntrega;

            return compra;
        }
    }
}

