using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDto
{
    public class CompraDto
    {
        [Required]
        public int CodigoProducto { get; set; }
        [Required]
        public int DniCliente { get; set; }
        [Required]
        public int CantidadComprada { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }

    }
}
