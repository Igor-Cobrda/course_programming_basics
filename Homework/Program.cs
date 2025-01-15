using System.Text.Json;

namespace Homework 
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" PROGRAM NA ZISTENIE VÝCHODU-ZÁPADU SLNKA a MESIACA");
            Console.WriteLine();
            string jsonString = await getPublicApiDataAsync();
            if (jsonString != null) deserializeJsonMessage(jsonString); else Console.WriteLine(" Odpoveď je prázdna - špatné parametre na vstupe ");
        }

        // Ukazka volani https://www.weatherapi.com/api-explorer.aspx#current API
        // pro vyzkouseni musime mit vlastni validni apiKey. Ten ziskate po bezplatne registraci
        public static async Task<string> getPublicApiDataAsync()
        {
            string responseBody = null;
            try
            {
                using HttpClient client = new HttpClient();

                // url adresa api vcetne parametru
                const string apiKey = "d0f1dd626e1c4705af0164004250401";
                string city = null;
                Console.Write("Zadaj mesto (prázdne=Senica): ");
                city = Console.ReadLine();
                if (city == "") { city = "Senica"; }
                DateTime dnesnyDatum = DateTime.Now;
                int dnesnyRok = dnesnyDatum.Year;
                int dnesnyMes = dnesnyDatum.Month;
                int dnesnyDay = dnesnyDatum.Day;
                string dnesnyDatumInak = $"{dnesnyRok}-{dnesnyMes}-{dnesnyDay}";
                Console.Write($"Zadaj dátum v tvare (2025-01-15)(prázdne={dnesnyDatumInak}): ");
                string date = null;
                date = Console.ReadLine();
                if (date == "") { date = dnesnyDatumInak; }
                string url = $"http://api.weatherapi.com/v1/astronomy.json?key={apiKey}&q={city}&dt={date}";
                Console.WriteLine(url);
                Console.WriteLine();

                // zavolani GET metody API a získání odpovědi
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // precteni body z odpovedi (json objekt)
                responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.Message);
            }
            return responseBody;
        }

        public static void deserializeJsonMessage(string jsonString)
        {
            var message = JsonSerializer.Deserialize<Message>(jsonString);

            Console.WriteLine();
            Console.WriteLine("Deserialized:");
            Console.WriteLine();
            Console.WriteLine($"Mesto: {message.location.Name}");
            Console.WriteLine($"Kraj:  {message.location.Region}");
            Console.WriteLine($"Štát:  {message.location.Country}");
            Console.WriteLine($"Poloha: z.šírka: {message.location.Lat}");
            Console.WriteLine($"        z.dĺžka: {message.location.Lon}");
            Console.WriteLine($"Lokálny čas: {message.location.LocalTime}");
            Console.WriteLine();
            Console.WriteLine($"Východ Slnka: {message.astronomy.astro.SunRise}");
            Console.WriteLine($"Západ  Slnka: {message.astronomy.astro.SunSet}");
            Console.WriteLine();
            Console.WriteLine($"Východ Mesiaca: {message.astronomy.astro.MoonRise}");
            Console.WriteLine($"Západ  Mesiaca: {message.astronomy.astro.MoonSet}");
            Console.WriteLine($"Jas    Mesiaca: {message.astronomy.astro.MoonIllumination} %");
            Console.WriteLine();
            Console.WriteLine("PRE UKONČENIE STLAČ KLÁVESU");
            Console.ReadKey();  
        }
    }
}
