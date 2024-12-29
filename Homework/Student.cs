namespace Homework
{ 
    internal class Student
    {

        internal string _name;
        internal int _age;
        internal List<int> _grades;

        internal Student(string name, int age, List<int> grades)
        {
            _name = name;
            _age = age;
            _grades = grades;
        }

        internal void DisplayStudentInfo()
        {
            Console.Write(_name + "  " + _age + " -");
            foreach (var znamka in _grades)
            {
                Console.Write(" " + znamka);
            }
            Console.WriteLine();
        }
    }
}
