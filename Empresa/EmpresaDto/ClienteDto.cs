using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDto
{
    public class ClienteDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Telefono { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
