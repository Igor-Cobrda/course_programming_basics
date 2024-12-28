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
            Console.WriteLine(_name + "  " + _age + " - " + _grades[0] + " " + _grades[1] + " " + _grades[2]);
        }
    }
}
