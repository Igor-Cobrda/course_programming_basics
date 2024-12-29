namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vytvorený zoznam študentov:");
            List<Student> zoznamStudentov = vytvorZoznamStudentov();
            Console.WriteLine();


            Console.WriteLine("Zoznam mien všetkých študentov:");
            var zoznamMienStudentov = zoznamStudentov.Select(student => student._name);
            foreach (var name in zoznamMienStudentov)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Študenti ktorý majú aspoň jednu známku vyššiu ako 90:");
            var zoznamNajlepsichStudentov = zoznamStudentov.Where(student => student._grades.Any(e => e > 90));
            foreach (var student in zoznamNajlepsichStudentov)
            {
                Console.Write(student._name + "  " + student._age + " -");
                foreach (var znamka in student._grades)
                {
                    Console.Write(" " + znamka);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            Console.WriteLine("Overenie či existuje študent, ktorý má všetky známky väčšie ako 80:");
            var existujeStudent80 = zoznamStudentov.Any(student => student._grades.All(e => e > 80));
            if (existujeStudent80) { Console.WriteLine("Študent existuje"); }
            else { Console.WriteLine("Študent neexistuje"); }
            Console.WriteLine();


            Console.WriteLine("Zoznam známok všetkých študentov:");
            var zoznamZnamokStudentov = zoznamStudentov.SelectMany(student => student._grades);
            foreach (var student in zoznamZnamokStudentov)
            {
                Console.Write(student + ",");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Zoradenie študentov podľa veku:");
            var zoradenyZoznamPodlaVeku = zoznamStudentov.OrderBy(student => student._age);
            foreach (var student in zoradenyZoznamPodlaVeku)
            {
                Console.Write(student._name + "  " + student._age + " -");
                foreach (var znamka in student._grades)
                {
                    Console.Write(" " + znamka);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static List<Student> vytvorZoznamStudentov()
        {
            var random = new Random();
            var names = new List<string> { "Alice  ", "Bob    ", "Charlie", "Diana  ", "Edward ", "Fiona  ", "George ", "Hannah ", "Ian    ", "Julia  " };
            var students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                var student = new Student(i + "-" + names[random.Next(names.Count)], random.Next(18, 25), new List<int> { random.Next(20, 100), random.Next(50, 100), random.Next(70, 100) });
                students.Add(student);
                student.DisplayStudentInfo();
            }
            return students;
        }
    }
}
