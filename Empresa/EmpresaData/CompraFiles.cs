using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaEntities;
using Newtonsoft.Json;

namespace EmpresaData
{
    public class CompraFiles
    {
        private static string rutaCompras = Path.GetFullPath("Compras.json");

        public static List<Compra> LeerComprasDesdeJson()
        {
            if (File.Exists($"{rutaCompras}"))
            {
                var json = File.ReadAllText($"{rutaCompras}");
                return JsonConvert.DeserializeObject<List<Compra>>(json);
            }
            else
            {
                return new List<Compra>();
            }

        }

        public static void EscribirComprasAJson(Compra compra)
        {
            List<Compra> Compras = LeerComprasDesdeJson();

            if (compra.Codigo == 0)
            {
                compra.Codigo = Compras.Count() + 1;
                compra.FechaCompra = DateTime.Now;
            }
            else
            {
                Compras.RemoveAll(x => x.Codigo == compra.Codigo);

            }


            Compras.Add(compra);

            var json = JsonConvert.SerializeObject(Compras, Formatting.Indented);
            File.WriteAllText($"{rutaCompras}", json);
        }
    }
}
