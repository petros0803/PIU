using System;
using LibrarieModele;
using NivelAccesDate;

namespace EvidentaStudenti
{
    class Program
    {
        static void Main(string[] args)
        {
            //variabila de tip interfata 'IStocareData' care este initializata 
            //cu o instanta a clasei 'AdministrareStudenti_FisierText' sau o instanta a clasei 'AdministrareStudenti_FisierBinar' in functie de setarea 'FormatSalvare' din fisierul AppConfig
            IStocareData adminStudenti = StocareFactory.GetAdministratorStocare();

            string optiune;
            do
            {
                Console.WriteLine("L. Listare studenti");
                Console.WriteLine("A. Adaugare student");
                Console.WriteLine("C. Cauta student");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                Console.Clear();
                switch (optiune.ToUpper())
                {
                    case "L":
                        int nrStudenti;
                        Student[] studenti = adminStudenti.GetStudenti(out nrStudenti);
                        if (nrStudenti > 0)
                        {
                            Student.IdUltimStudent = studenti[nrStudenti - 1].IdStudent;
                        }

                        AfisareStudenti(studenti, nrStudenti);
                        break;
                    case "A":
                        Student stud_tastatura = CitireStudentTastatura();
                        //adaugare student in fisier
                        adminStudenti.AddStudent(stud_tastatura);
                        break;
                    case "C":
                        Console.WriteLine("Introduceti nume persoana cautata:");
                        string Nume_temporar = Console.ReadLine();
                        Console.WriteLine("Introduceti prenume persoana cautata:");
                        string Prenume_temporar = Console.ReadLine();
                        Student stud_cautat = adminStudenti.GetStudent(Nume_temporar,Prenume_temporar);
                        if (stud_cautat != null)
                        {
                            Console.WriteLine("Studentul cautat este: {0}", stud_cautat.ConversieLaSir());
                        }
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }


        public static void AfisareStudenti(Student[] studenti, int nrStudenti)
        {
            Console.WriteLine("Studentii sunt:");
            for (int i = 0; i < nrStudenti; i++)
            {
                Console.WriteLine(studenti[i].ConversieLaSir());
            }
        }
        public static Student CitireStudentTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti notele separate prin spatiu");
            string note = Console.ReadLine();

            Student s = new Student(nume, prenume);
            s.SetNote(note);

            Console.WriteLine("Dati programul de studiu: \n 1.Calculatoare \n 2.Automatica \n 3.Electronica \n 4.Electrotehnica \n 5.Energetica \n 6.InginerieEconomica ");
            s.ProgramSTD = (ProgramStudiu)Int32.Parse(Console.ReadLine());
            Console.Clear();
            return s;
        }

    }

}
