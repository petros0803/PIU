using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
    //TREBUIE MODIFICAT MAINUL CARE SE DORESTE 
    //Am doua mainuri --- UNUL DE TESTARE CU DATE PRESCRISE [NU ARE TOATE FUNCTIONALITATILE]--- UNUL CU CITIRI ---
    //******************SETAT CEL DE TESTAT CU DATE PRESCRISE******************
    //Adaugare student - PRENUME, NUME, AN DE STUDIU, NOTELE DESPARTITE PRIN SPATIU, SPECIALIZARE,
    //NUMARUL + LIMBAJELE DE PROGRAMARE PREFERATE DESPARTITE PRIN ENTER (1 PE RAND).

    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            string option;

            while (true)
            {
                bool ok = true;
                int index = 0, studyYear, count;
                string grades;
                string line = string.Empty;
                StudentProgrammingLanguages languages = StudentProgrammingLanguages.None;

                Menu();
                Console.WriteLine("*********************SUNT 3 STUDENTI ADAUGATI*********************");

                students.Add(new Student("Serban Mihai", "Caliniuc", 2, "5 6 5", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cpp));
                students.Add(new Student("mamaam", "nanaaann", 2, "5 6 5", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cpp));
                students.Add(new Student("Bogdan Ciprian", "Petrosceac", 2, "8 7 7", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cs | StudentProgrammingLanguages.JS |
                                                                                 StudentProgrammingLanguages.CSS | StudentProgrammingLanguages.Py | StudentProgrammingLanguages.HTML));

                Console.WriteLine("Optiunea aleasa: ");
                option = Console.ReadLine();
                switch (option.ToUpper())
                {

                    case "A":
                        Console.WriteLine("Prenumele: ");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Numele: ");
                        string LastName = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Anul de studiu: ");
                            studyYear = Int32.Parse(Console.ReadLine());
                            ok = Student.ValidateStudyYear(studyYear);
                        } while (ok != true);

                        do
                        {
                            Console.WriteLine("Note: ");
                            grades = Console.ReadLine();
                            ok = Student.GradeConversion(grades);
                        } while (ok != true);

                        foreach (string specs in Enum.GetNames(typeof(FacultySpecialization)))
                        {
                            if (specs != "None")
                                Console.WriteLine(index + "." + specs);
                            index++;
                        }
                        Console.WriteLine("Specialiazre: ");
                        string Specialization = Console.ReadLine();
                        int val = Int32.Parse(Specialization);
                        index = 0;
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

                        students.Add(new Student(FirstName, LastName, studyYear, grades, (FacultySpecialization)val, languages));
                        break;
                    case "B":
                        StreamWriter sw = new StreamWriter("C:/Users/Bobo/source/repos/Tema3/TextFiles/Test.txt");
                        Console.WriteLine("Sunt {0} studenti inregistrati", students.Count);
                        foreach (var stud in students)
                            sw.WriteLine(stud.ToString());
                        sw.Close();
                        break;
                    case "C":
                        StreamReader sr = new StreamReader("C:/Users/Bobo/source/repos/Tema3/TextFiles/Test.txt");
                        while (line != null)
                        {
                            string firstName = string.Empty, lastName = string.Empty;
                            Guid studentID = Guid.Empty;
                            studyYear = 0;
                            double average = 0.0;
                            FacultySpecialization specializare = FacultySpecialization.None;
                            languages = StudentProgrammingLanguages.None;
                            for (index = 0; index < 7; index++)
                            {
                                line = sr.ReadLine();
                                if (line == null)
                                {
                                    break;
                                }
                                string[] elems = line.Split(' ');

                                if (index == 0)
                                {
                                    studentID = Guid.Parse((elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' })));
                                }
                                else if (index == 1)
                                {
                                    foreach (string elem in elems.Skip(1).Take(elems.Length - 2))
                                    {
                                        firstName = firstName + ' ' + elem;
                                    }
                                    lastName = elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' });
                                }
                                else if (index == 2)
                                {
                                    foreach (string elem in elems.Skip(3).Take(1))
                                    {
                                        studyYear = Int32.Parse(elem.Trim(new Char[] { ' ', '*', '.' }));
                                    }
                                }
                                else if (index == 3)
                                {
                                    var elem = elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' });
                                    Enum.TryParse(elem, out FacultySpecialization specialization);
                                    specializare = specialization;
                                }
                                else if (index == 4)
                                    average = Double.Parse(elems[elems.Length - 1]);
                                else if (index == 6)
                                {
                                    foreach (string elem in elems.Skip(2).Take(elems.Length - 2))
                                    {
                                        Enum.TryParse(elem.Trim(new Char[] { ' ', '*', '.', ',' }), out StudentProgrammingLanguages programming);
                                        languages = languages | programming;
                                    }
                                }
                            }
                            line = sr.ReadLine();
                            if (firstName == string.Empty)
                                break;
                            students.Add(new Student(studentID, firstName, lastName, studyYear, average, specializare, languages));
                        }
                        foreach (var stud in students)
                            Console.WriteLine(stud.ToString());
                        sr.Close();
                        break;
                    case "D":
                        Console.WriteLine("Prenume: ");
                        string temporaryFirstName = Console.ReadLine();
                        Console.WriteLine("Nume: ");
                        string temporaryLastName = Console.ReadLine();
                        foreach (var stud in students)
                        {
                            var result = Student.SearchAndModifyStudent(temporaryFirstName, temporaryLastName, stud);
                        }
                        break;
                    case "X":
                        System.Environment.Exit(1);
                        break;

                }
            }
        }

        static void asdasd()
        {
            //Student obj = new Student("Bobo", "Bobo", 2, 5, FacultySpecialization.Calculatoare);
            List<Student> students = new List<Student>();
            students.Add(new Student("Bogdan Ciprian", "Petrosceac", 2, "8 7 7", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cs|StudentProgrammingLanguages.JS|
                                                                                 StudentProgrammingLanguages.CSS|StudentProgrammingLanguages.Py|StudentProgrammingLanguages.HTML));
            students.Add(new Student("Serban Mihai", "Caliniuc", 2, "5 6 5", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cpp));
            students.Add(new Student("Razvan", "Ailenei", 2, "8 8 4", FacultySpecialization.Calculatoare, StudentProgrammingLanguages.Cs|StudentProgrammingLanguages.C));

            foreach (var elem in students)
            {
                Console.WriteLine(elem.ToString());
            }
            Console.WriteLine(students[0] == students[1]);

            //INCEPE

            StreamReader sr = new StreamReader("C:/Users/Bobo/source/repos/Tema3/TextFiles/Test.txt");

            string studentID = string.Empty, firstName = string.Empty, lastName = string.Empty;
            int studyYear = 0;
            double average = 0.0;
            FacultySpecialization specializare = FacultySpecialization.None;
            StudentProgrammingLanguages languages = StudentProgrammingLanguages.None;

            for(int index = 0; index < 7; index++)
            {
                string line = sr.ReadLine();
                string[] elems = line.Split(' ');

                if (index == 0)
                {
                    studentID = (elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' }));
                }
                else if (index == 1)
                {
                    foreach (string elem in elems.Skip(1).Take(elems.Length-2))
                    {
                        firstName = firstName + ' ' + elem;
                    }
                    lastName = elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' });
                }
                else if (index == 2)
                {
                    foreach (string elem in elems.Skip(3).Take(1))
                    {
                        studyYear = Int32.Parse(elem.Trim(new Char[] { ' ', '*', '.' }));
                    }
                }
                else if (index == 3)
                {
                    var elem = elems[elems.Length - 1].Trim(new Char[] { ' ', '*', '.' });
                    Enum.TryParse(elem, out FacultySpecialization specialization);
                    specializare = specialization;
                }
                else if (index == 4)
                    average = Double.Parse(elems[elems.Length - 1]);
                else if (index == 6)
                {
                    foreach (string elem in elems.Skip(2).Take(elems.Length-2))
                    {
                        Enum.TryParse(elem.Trim(new Char[] { ' ', '*', '.', ',' }), out StudentProgrammingLanguages programming);
                        languages = languages | programming;
                    }
                }
                

            }
            //SE TERMINA
            Console.ReadKey();
        }

        public static void Menu()
        {
            Console.WriteLine("A.Adauga student.");
            Console.WriteLine("B.Afiseaza toti studentii.");
            Console.WriteLine("C.Citeste studentii din fisier.");
            Console.WriteLine("D.Compara notele a 2 studenti.");
            Console.WriteLine("E.Cauta un student dupa nume si modifica-i datele.");
            Console.WriteLine("X.Inchide program.");
        }
    }
}
