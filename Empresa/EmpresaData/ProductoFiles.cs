using EmpresaEntities;
using Newtonsoft.Json;
namespace EmpresaData
{
    public class ProductoFiles
    {
        private static string rutaProductos = Path.GetFullPath("Productos.json");

        public static List<Producto> LeerProductosDesdeJson()
        {
            if (File.Exists($"{rutaProductos}"))
            {
                var json = File.ReadAllText($"{rutaProductos}");
                return JsonConvert.DeserializeObject<List<Producto>>(json);
            }
            else
            {
                return new List<Producto>();
            }

        }

        public static void EscribirProductosAJson(Producto producto)
        {
            List<Producto> productos = LeerProductosDesdeJson();

            if (producto.CodigoUnico == 0)
            {
                producto.CodigoUnico = productos.Count() + 1;
               
            }
            else
            {
                productos.RemoveAll(x => x.CodigoUnico == producto.CodigoUnico);

            }


            productos.Add(producto);

            var json = JsonConvert.SerializeObject(productos, Formatting.Indented);
            File.WriteAllText($"{rutaProductos}", json);
        }
    }
}
