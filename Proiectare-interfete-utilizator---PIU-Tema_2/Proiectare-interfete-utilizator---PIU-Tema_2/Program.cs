using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_PIU
{
    class Program
    {
        static void Main()
        {
            var student = new Student("Bobo", 2);

            char choice;

            while (true)
            {
                menu();
                Console.WriteLine("Alegere: ");
                choice = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (choice)
                {
                    
                    case 'S':
                        Console.WriteLine("\nNota Studentului: ");
                        string grade = Console.ReadLine();
                        student.SetStudentGrade(grade);
                        break;
                    case 'C':
                        student.SetStudentGrade("5 6 7 8 9");
                        break;
                    case 'A':
                        Console.WriteLine('\n' + student.DisplayStudent());
                        break;
                    case 'I':
                        Console.WriteLine("P.B.C. style");
                        break;
                    case 'X':
                        Environment.Exit(1);
                        break;
                    case 'T':
                        Console.WriteLine("\nNumarul de note de introdus: ");
                        int counter = Int32.Parse(Console.ReadLine());
                        int[] grades = new int[counter]; 
                        for (int index = 0; index < counter; index++)
                        {
                            Console.WriteLine("\nNota: ");
                            int temp = Int32.Parse(Console.ReadLine());
                            grades[index] = temp;
                        }
                        student.SetStudentGrade(grades);
                        break;
                }
            }
            Console.ReadKey();
        }

        static void menu()
        {
            Console.WriteLine("S.Citeste de la tastatura notele.");
            Console.WriteLine("T.Citeste cate o nota de la tastatura.");
            Console.WriteLine("C.Scrie notele.");
            Console.WriteLine("A.Afisare informatii student.");
            Console.WriteLine("I.Info autor.");
            Console.WriteLine("X.Iesire.");
        }

    }
}
