using System;
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
    //NU AM CITIREA DIN FISIER, DACA APUC O FAC MAINE

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
                StudentProgrammingLanguages languages = StudentProgrammingLanguages.None;

                Menu();

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
                                Console.WriteLine(index-1 + "." + limbaje);
                            index++;
                        }
                        Console.WriteLine("Cate limbaje de programare adaugati? ");
                        count = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Adauga limbajele despartite de un ENTER: ");
                        for(; count > 0; count--)
                        {
                            int temp = Int32.Parse(Console.ReadLine());
                            languages = languages | (StudentProgrammingLanguages)(1 << temp);
                        }

                        students.Add(new Student(FirstName, LastName, studyYear, grades, (FacultySpecialization)val, languages));
                        //Console.WriteLine(students[0]);
                        break;
                    case "B":
                        Console.WriteLine(students.Count);
                        foreach(var stud in students)
                            Console.WriteLine(stud.ToString());
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

            var x = StudentProgrammingLanguages.Cs|StudentProgrammingLanguages.Cpp|StudentProgrammingLanguages.JS;
            x = x | StudentProgrammingLanguages.HTML;
            Console.WriteLine(x);
            Console.ReadKey();
        }

        public static void Menu()
        {
            Console.WriteLine("A.Adauga student.");
            Console.WriteLine("B.Afiseaza toti studentii.");
            Console.WriteLine("C.Compara notele a 2 studenti.");
            Console.WriteLine("D.Cauta un student dupa nume si modifica-i datele.");
        }
    }
}
