namespace Homework
{
    internal class Lesson5
    {
        public static void Demo()
        {
            Console.WriteLine("Zadaj údaje prvej osoby:");
            zadavanieHodnotaVypocetBmi();
            Console.WriteLine("Zadaj údaje druhej osoby:");
            zadavanieHodnotaVypocetBmi();
        }

        // FUNKCIE:

        static void zadavanieHodnotaVypocetBmi()
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");

            string menoOsoby = zadajMenoOsoby();

            Console.Write("priezvisko: ");
            string priezviskoOsoby = Console.ReadLine();

            Console.Write("vek: ");
            string vekOsoby = Console.ReadLine();

            float vahaOsoby = zadajVahuOsoby();

            int vyskaOsoby = zadajVyskuOsoby();

            Console.WriteLine("");
            Console.WriteLine(menoOsoby + " " + priezviskoOsoby + " je starý/á " + vekOsoby + " rokov. Váži " + vahaOsoby + " kilogramov a je " + vyskaOsoby + " centimetrov vysoký/á.");

            double bmiOsoby = vypocetBMI(vahaOsoby, vyskaOsoby);

            Console.WriteLine("Jeho/Jej index telesnej hmotnosti BMI je: " + bmiOsoby);
            Console.WriteLine("");

            int kategoriaOsoby = zistiKategoriu(bmiOsoby);
            Console.Write("Podľa indexu telesnej hmotnosti spadá do kategórie: ");
            switch (kategoriaOsoby)
            {
                case 1:
                    Console.WriteLine("Podváha");
                    break;
                case 2:
                    Console.WriteLine("Normálna váha");
                    break;
                case 3:
                    Console.WriteLine("Nadváha");
                    break;
                case 4:
                    Console.WriteLine("Obezita");
                    break;
                default:
                    Console.WriteLine("Slon");
                    break;
                }
            Console.WriteLine("");
            }


        static string zadajMenoOsoby()
        {
            Console.Write("meno: ");
            string menoOsobyRet = Console.ReadLine();
            return menoOsobyRet;
        }


        static float zadajVahuOsoby()
        {
            Console.Write("váha v kg: ");
            string vahaOsobyRet = Console.ReadLine();
            float vahaOsobyCislo = float.Parse(vahaOsobyRet);
            return vahaOsobyCislo;
        }

        static int zadajVyskuOsoby()
        {
            Console.Write("výška v cm: ");
            string vyskaOsobyRet = Console.ReadLine();
            int vyskaOsobyCislo = int.Parse(vyskaOsobyRet);
            return vyskaOsobyCislo;
        }

        static double vypocetBMI(float vahaOsoby, int vyskaOsoby)
        {
            double vyskaOsobyvMetroch = vyskaOsoby * 0.01;
            double vypocetBmiOsoby = vahaOsoby / (vyskaOsobyvMetroch * vyskaOsobyvMetroch);
            return vypocetBmiOsoby;
        }

        static int zistiKategoriu(double bmiOsoby)
        {
            if (bmiOsoby < 18.5) { return 1; }
            if ((bmiOsoby >= 18.5) && (bmiOsoby < 25.0)) { return 2; }
            if ((bmiOsoby >= 25.0) && (bmiOsoby < 30.0)) { return 3; }
            if (bmiOsoby >= 30.0) { return 4; }
            return 0;
        }
    }
}