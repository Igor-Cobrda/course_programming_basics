namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skúška, či funguje moja vytvorená výjimka");
            var product1 = new Product("Tehla", 10f, 10);
            Console.WriteLine(product1.Name + "  " + product1.Price + "  " + product1.Quantity);
            var product2 = new Product("Kvader", -10f, 20);
            Console.WriteLine(product2.Name + "  " + product2.Price + "  " + product2.Quantity);
            Console.WriteLine();

            // Naplnenie Listu Catalog
            var catalogs = new List<Catalog>();
            var product = new List<Product>();
            product.Add(new Product("Tehla", 10f, 10));
            product.Add(new Product("Kvader", 100f, 20));
            product.Add(new Product("Piesok", 50.5f, 1));
            var catalog1 = new Catalog(new List<Product>(product));
            catalogs.Add(catalog1);
            product.RemoveRange(0,3);
            product.Add(new Product("Košeľa", 25.3f, 45));
            product.Add(new Product("Sveter", 30f, 12));
            var catalog2 = new Catalog(new List<Product>(product));
            catalogs.Add(catalog2);

            // Serializacia Produktov v Liste Catalog
            var serializeProduct = new List<string>();
            foreach (var catalog in catalogs)
            {
                serializeProduct = catalog.allProduktsSerializeJson(catalogs);
                return;
            }

            // Deserializacia Produktu do Listu Catalog
            var novyProdukt = new List<string> { "[{},{},{}]" };
            var deserializeProduct = new List<Product>();
            try
            {
                foreach (var catalog in catalogs)
                {
                    deserializeProduct = catalog.produktsDeserializeJson(novyProdukt);
                    return;
                }
                var catalog3 = new Catalog(new List<Product>(deserializeProduct));
                catalogs.Add(catalog3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
