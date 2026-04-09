using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDto
{
    public class ViajeDto
    {
        [Required]
        public DateTime FechaDesde { get; set; }
        [Required]
        public DateTime FechaHasta { get; set; }
    }
}
