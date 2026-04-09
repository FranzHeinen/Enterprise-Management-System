using EmpresaEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData
{
    public class CamionetaFiles
    {
        private static string rutaCamionetas = Path.GetFullPath("Camionetas.json");

        public static List<Camioneta> LeerCamionetasDesdeJson()
        {
            if (File.Exists($"{rutaCamionetas}"))
            {
                var json = File.ReadAllText($"{rutaCamionetas}");
                return JsonConvert.DeserializeObject<List<Camioneta>>(json);
            }
            else
            {
                return new List<Camioneta>();
            }

        }

        public static void EscribirCamionetasAJson(Camioneta camioneta)
        {
            List<Camioneta> Camionetas = LeerCamionetasDesdeJson();

            Camionetas.Add(camioneta);

            var json = JsonConvert.SerializeObject(Camionetas, Formatting.Indented);
            File.WriteAllText($"{rutaCamionetas}", json);
        }
    }
}
