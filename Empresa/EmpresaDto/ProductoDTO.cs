using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDto
{
    public class ProductoDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public double AltoCajaCm { get; set; }
        [Required]
        public double AnchoCajaCm { get; set; }
        [Required]
        public double ProfundidadCajaCm { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        [Required]
        public int StockMinimo { get; set; }
        [Required]
        public int CantidadStock { get; set; }

      
    }
}
