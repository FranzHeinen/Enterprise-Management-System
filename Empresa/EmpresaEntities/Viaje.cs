using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaEntities
{
    public class Viaje
    {
        public int Codigo { get; set; }
        public string PatenteCamionetaAsignada { get; set; }
        public DateTime FechaEntregaPosibleDesde { get; set; }
        public DateTime FechaEntregaPosibleHasta { get; set; }
        public double Capacidad { get; set; }
        public List<int> CodigosCompras { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public Viaje()
        {
            CodigosCompras = new List<int>();
        }


    }
}
