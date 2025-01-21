using System.Text.Json;

namespace Homework
{
    public class Message
    {
        public Location location { get; set; }
        public Astronomy astronomy { get; set; }


        public static string zadavanieMesta(string city)
        {
            if (city == "") { city = "Senica"; }
            var numCity = int.TryParse(city, out var _);
            if (numCity == true) { city = "Senica"; }
            return city;
        }

        public static string zadavanieDatumu(string date, string dnesnyDatumInak)
        {
            if (date == "") { date = dnesnyDatumInak; }
            return date;
        }

        //Posielanie poziadavky a prijem spravy
        // Ukazka volani https://www.weatherapi.com/api-explorer.aspx#current API
        // pro vyzkouseni musime mit vlastni validni apiKey. Ten ziskate po bezplatne registraci
        public static async Task<string> getPublicApiDataAsync(string city, string date)
        {
            string responseBody = null;
            try
            {
                using HttpClient client = new HttpClient();

                // url adresa api vcetne parametru
                const string apiKey = "d0f1dd626e1c4705af0164004250401";
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

        public static Message deserializeJsonMessage(string jsonString)
        {
            var message = JsonSerializer.Deserialize<Message>(jsonString);
            return message;
        }
    }
}
