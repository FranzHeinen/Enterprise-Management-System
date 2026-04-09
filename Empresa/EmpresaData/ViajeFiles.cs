using EmpresaEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData
{
    public class ViajeFiles
    {
        private static string rutaViajes = Path.GetFullPath("Viajes.json");

        public static List<Viaje> LeerViajesDesdeJson()
        {
            if (File.Exists($"{rutaViajes}"))
            {
                var json = File.ReadAllText($"{rutaViajes}");
                return JsonConvert.DeserializeObject<List<Viaje>>(json);
            }
            else
            {
                return new List<Viaje>();
            }

        }

        public static void EscribirViajesAJson(Viaje viaje)
        {
            List<Viaje> viajes = LeerViajesDesdeJson();

            if (viaje.Codigo == 0)
            {
                viaje.Codigo = viajes.Count() + 1;
            }
            else
            {
                viajes.RemoveAll(x => x.Codigo == viaje.Codigo);

            }


            viajes.Add(viaje);

            var json = JsonConvert.SerializeObject(viajes, Formatting.Indented);
            File.WriteAllText($"{rutaViajes}", json);
        }
    }
}
