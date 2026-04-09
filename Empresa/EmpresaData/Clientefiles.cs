using EmpresaEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData
{
    public class ClienteFiles
    {
        private static string rutaClientes = Path.GetFullPath("Clientes.json");

        public static List<Cliente> LeerClientesDesdeJson()
        {
            if (File.Exists($"{rutaClientes}"))
            {
                var json = File.ReadAllText($"{rutaClientes}");
                return JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
            else
            {
                return new List<Cliente>();
            }

        }

        public static void EscribirClientesAJson(Cliente cliente)
        {
            List<Cliente> Clientes = LeerClientesDesdeJson();

            if (cliente.FechaActualizacion != null || cliente.FechaEliminacion != null)
            {
                Clientes.RemoveAll(x => x.Dni == cliente.Dni);

            }


            Clientes.Add(cliente);

            var json = JsonConvert.SerializeObject(Clientes, Formatting.Indented);
            File.WriteAllText($"{rutaClientes}", json);
        }
    }
}
