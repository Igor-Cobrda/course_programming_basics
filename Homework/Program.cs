namespace Homework 
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" PROGRAM NA ZISTENIE VÝCHODU-ZÁPADU SLNKA a MESIACA");
            Console.WriteLine();

            // Zadavanie mesta
            string city = null;
            Console.Write("Zadaj mesto (prázdne=Senica): ");
            city = Console.ReadLine();
            city = Message.zadavanieMesta(city);

            //Zadavanie datumu
            DateTime dnesnyDatum = DateTime.Now;
            int dnesnyRok = dnesnyDatum.Year;
            int dnesnyMes = dnesnyDatum.Month;
            int dnesnyDay = dnesnyDatum.Day;
            string dnesnyDatumInak = $"{dnesnyRok}-{dnesnyMes}-{dnesnyDay}";
            Console.Write($"Zadaj dátum v tvare (YYYY-MM-DD)(prázdne={dnesnyDatumInak}): ");
            string date = null;
            date = Console.ReadLine();
            date = Message.zadavanieDatumu(date, dnesnyDatumInak);

            //Posielanie poziadavky a prijem spravy
            string jsonString = await Message.getPublicApiDataAsync(city, date);

            //Deserializacia spravy
            Message message = new Message();
            if (jsonString != null)
            {
                message = Message.deserializeJsonMessage(jsonString);
            }
            else
            {
                Console.WriteLine(" Odpoveď je prázdna - špatné parametre na vstupe ");
            }

            // Vypisanie spravy na konzolu
            if (message != null)
            {
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
}
