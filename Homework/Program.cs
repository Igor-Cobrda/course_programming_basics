using System.Text.Json;

namespace Homework
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            Task<string> jsonString = getPublicApiDataAsync();
            deserializeJsonMessage(jsonString);
        }

        // Ukazka volani https://www.weatherapi.com/api-explorer.aspx#current API
        // pro vyzkouseni musime mit vlastni validni apiKey. Ten ziskate po bezplatne registraci
        internal static async Task<string> getPublicApiDataAsync()
        {
            string responseBody = null;
            try
            {
                using HttpClient client = new HttpClient();

                // url adresa api vcetne parametru
                const string apiKey = "d0f1dd626e1c4705af0164004250401";
                const string city = "Senica";
                const string date = "2025-01-05";
                string url = $"http://api.weatherapi.com/v1/astronomy.json?key={apiKey}&q={city}&dt={date}";
                Console.WriteLine(url);

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

        internal static void deserializeJsonMessage(Task<string> jsonString)
        {
            string json = jsonString.Result;
            var message = JsonSerializer.Deserialize<Message>(json);

            Console.WriteLine("Deserialized:");
            Console.WriteLine(message);
        }
    }
}
