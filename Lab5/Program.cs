using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab5
{
    struct Student
    {
        public string SurName;
        public string FirstName;
        public string Patronymic;
        public char Sex;
        public string DateOfBirth;
        public char MathematicsMark;
        public char PhysicsMark;
        public char InformaticsMark;
        public int Scholarship;
    }

    class Students
    {
        List<Student> _students;
        string _filename;

        public Students(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            _filename = file;
            _students = new List<Student>();
            MakeStructFromFile();
        }

        private void MakeStructFromFile()
        {
            string[] words = File.ReadAllText(_filename).Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                _students.Add(new Student
                {
                    SurName = words[i++],
                    FirstName = words[i++],
                    Patronymic = words[i++],
                    Sex = Convert.ToChar(words[i++]),
                    DateOfBirth = words[i++],
                    MathematicsMark = Convert.ToChar(words[i++]),
                    PhysicsMark = Convert.ToChar(words[i++]),
                    InformaticsMark = Convert.ToChar(words[i++]),
                    Scholarship = Convert.ToInt16(words[i++])
                });
            }
        }

        public void RunLab()
        {
            _students = _students.ToList();
            int sum = 0;
            int counter = 0;
            foreach (Student st in _students)
            {
                if (st.Scholarship > 0)
                {
                    sum += st.Scholarship;
                    counter++;
                }
            }

            int average = sum / counter;
            double averageWithPercent = average - average * 0.2;
            Console.WriteLine("Average scholarship is: " + average);
            foreach (Student st in _students)
            {
                if (st.Scholarship > 0)
                {
                    if (st.Scholarship < averageWithPercent)
                    {
                        Console.WriteLine(
                            "Student who has scholarship less that average for 20% or more(below {0} ) : {1} {2} {3} with scholarship: {4} ",
                            averageWithPercent, Convert.ToString(st.SurName), Convert.ToString(st.FirstName),
                            Convert.ToString(st.Patronymic), st.Scholarship);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Students st = new Students("input.txt");
            st.RunLab();

            Console.ReadKey();
        }
    }
}