using System.Text.Json;

namespace Homework
{
    internal class Catalog
    {
        internal List<Product> Products { get; }

        internal Catalog(List<Product> products) 
        {
            Products = products;
        }

        internal string produktsSerializeJson(List<Product> products) 
        {
            List<Product> produktNaSerializaciu = new List<Product>();
            produktNaSerializaciu = products.ToList();
            string json = JsonSerializer.Serialize(produktNaSerializaciu);
            Console.WriteLine("Serializovany objekt:");
            Console.WriteLine(json);
            return json;
        }

        internal List<string> allProduktsSerializeJson(List<Catalog> catalogs)
        {
            List<string> jsonProdukt = new List<string>();
            foreach (Catalog catalog in catalogs)
            {
                var json = produktsSerializeJson(catalog.Products);
                jsonProdukt.Add(json);
            }
            return jsonProdukt;
        }

        internal List<Product> produktsDeserializeJson(List<string> json)
        {
            List<Product> products = new List<Product>();
            foreach (string jsonProduk in json)
            {
                var product = JsonSerializer.Deserialize<Product>(jsonProduk);
                products.Add(product);
            }
            return products;
        }
    }
}
