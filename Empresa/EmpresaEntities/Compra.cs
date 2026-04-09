using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaEntities
{
    public class Compra
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public int DniCliente { get; set; }
        public int CantidadComprada { get; set; }
        public DateTime FechaEntrega { get; set; }
        public EnumTipoCompra Estado { get; set; }
        public double MontoTotal { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public double CalcularMontoTotal(double monto)
        {
            var montoTotal = monto * CantidadComprada;
            montoTotal += montoTotal * 21 / 100;
            if (CantidadComprada > 4)
            {
                montoTotal -= montoTotal * 25 / 100;
            }
            return montoTotal;
        }
    }

}


