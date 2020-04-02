using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
    internal class Student
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int StudyYear { get; private set; }
        public List<double> Grades { get; set; }
        public double Average { get; set; }
        //public int Grades { get; set; }
        public FacultySpecialization Specialization { get; private set; }
        public StudentProgrammingLanguages ProgrammingLanguages { get; set; }

        public Student() : this(string.Empty, string.Empty, 0, String.Empty, FacultySpecialization.None, StudentProgrammingLanguages.C) {  }

        public Student(string firstName, string lastName, int studyYear, string grades, FacultySpecialization specialization, StudentProgrammingLanguages programmingLanguages)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            StudyYear = studyYear;
            Grades = new List<double>();
            GradesConversion(grades);
            Specialization = specialization;
            ProgrammingLanguages = programmingLanguages;
        }

        public static bool ValidateGrades(double grade)
        {
            const double MIN_GRADE = 1.0;
            const double MAX_GRADE = 10.0;

            if (grade >= MIN_GRADE && grade <= MAX_GRADE)
                return true;
            return false;
        }

        public static bool ValidateStudyYear(int studyYear)
        {
            const int MIN_YEAR = 1;
            const int MAX_YEAR = 4;

            if (studyYear >= MIN_YEAR && studyYear <= MAX_YEAR)
                return true;
            return false;
        }

        public static string Promoted(double average)
        {
            const int MIN_GRADE = 5;

            if (average >= MIN_GRADE)
                return "PROMOVAT";
            return "NEPROMOVAT";
        }

        public void GradesConversion(string grades)
        {
            string[] elems = grades.Split(' ');
            foreach (string elem in elems)
            {
                Grades.Add(Double.Parse(elem));
            }
            AverageGrades();
        }

        public static bool GradeConversion(string grades)
        {
            string[] elems = grades.Split(' ');
            foreach (string elem in elems)
            {
                double val = Double.Parse(elem);
                if (ValidateGrades(val)!=true)
                    return false;
            }
            return true;
        }

        public void AverageGrades()
        {
            Average = Grades.Average();
        }

        public static string operator ==(Student x, Student y)
        {
            if (x.Average > y.Average)
                return String.Format("\nStudentul {0} {1} are nota mai mare decat {2} {3}", x.FirstName, x.LastName, y.FirstName, y.LastName);
            else if (x.Average < y.Average)
            {
                return String.Format("\nStudentul {0} {1} are nota mai mare decat {2} {3}", y.FirstName, y.LastName, x.FirstName, x.LastName);
            }
            return String.Format("\nStudentii {0} {1} si {2} {3} au aceeasi nota", x.FirstName, x.LastName, y.FirstName, y.LastName);
        }

        public static string operator !=(Student x, Student y)          
        {
            return "pass";
        }

        public static string SearchAndModifyStudent(string firstName, string lastName, Student a)
        {
            if(firstName == a.FirstName && lastName == a.LastName)
            {
                while (true)
                {
                    int index = 0, count = 0;
                    StudentProgrammingLanguages languages = StudentProgrammingLanguages.None;
                    Console.WriteLine("Ce doresti sa modifici? ");
                    Console.WriteLine(Menu());
                    int option = Int32.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            string primulNume = Console.ReadLine();
                            a.FirstName = primulNume;
                            break;
                        case 2:
                            string ultimulNume = Console.ReadLine();
                            a.LastName = ultimulNume;
                            break;
                        case 3:
                            int anulDeStudiu = Int32.Parse(Console.ReadLine());
                            a.StudyYear = anulDeStudiu;
                            break;
                        case 4:
                            string nota = Console.ReadLine();
                            a.Grades.Clear();
                            a.GradesConversion(nota);
                            break;
                        case 5:
                            int specializare = Int32.Parse(Console.ReadLine());
                            a.Specialization = (FacultySpecialization)specializare;
                            break;
                        case 6:
                            foreach (string limbaje in Enum.GetNames(typeof(StudentProgrammingLanguages)))
                            {
                                if (limbaje != "None")
                                    Console.WriteLine(index - 1 + "." + limbaje);
                                index++;
                            }
                            Console.WriteLine("Cate limbaje de programare adaugati? ");
                            count = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Adauga limbajele despartite de un ENTER: ");
                            for (; count > 0; count--)
                            {
                                int temp = Int32.Parse(Console.ReadLine());
                                languages = languages | (StudentProgrammingLanguages)(1 << temp);
                            }
                            a.ProgrammingLanguages = languages;
                            break;
                        case 7:
                            return "DONE";
                        default:
                            Console.WriteLine("Alegere gresita");
                            break;
                    }
                }
                

            }
            return "";
            
        }

        private static string Menu()
        {
            return ("***STUDENT GASIT***\n" +
                "1.Prenumele\t" +
                "2.Numele\t" +
                "3.Anul de studiu\t" +
                "4.Nota\t" +
                "5.Specializarea\t" +
                "6.Limbaje de programare\t" +
                "7.Oprire modificari.");
        }

        public override string ToString()
        {
            return string.Format("***Studentul cu id {0}***\n" +
                                 "--->Nume: {1} {2}.\n" +
                                 "--->Student in anul: {3}.\n" +
                                 "--->Specializarea: {4}.\n" +
                                 "--->Media: {6:F2}\n" +
                                 "--->Status: {5}.\n" +
                                 "--->Limbajele preferate: {7}.\n",
                                 Id, FirstName, LastName, StudyYear, Specialization, Promoted(Average), Average, ProgrammingLanguages);
        }
    }
}
