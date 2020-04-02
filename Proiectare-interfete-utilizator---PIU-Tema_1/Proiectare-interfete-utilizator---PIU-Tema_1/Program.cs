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
            string ceva, _name;
            int _studyYear, _grade;
            bool op = false;
            var obj = new student();

            Console.WriteLine("Numele Studentului: ");
            _name = Console.ReadLine();
            obj.SetStudentName(_name);

            while (op == false)
            {
                Console.WriteLine("Nota Studentului: ");
                _grade = Convert.ToInt32(Console.ReadLine());
                obj.SetStudentGrade(_grade);
                op = true;
            }
            
            op = false;

            while (op == false)
            {
                Console.WriteLine("Anul de studiu al Studentului: ");
                _studyYear = Convert.ToInt32(Console.ReadLine());
                obj.SetStudentStudyYear(_studyYear);
                op = true;
            }
            
            string kappa = obj.DisplayStudent();

            Console.WriteLine(kappa);

            while(true)
            {
                Console.WriteLine("Nota Studentului: ");
                ceva = Console.ReadLine();
                _grade = Int32.Parse(ceva);
                op = obj.SetStudentGrade(_grade);
                if(op == true)
                {
                    kappa = obj.DisplayStudent();
                    Console.WriteLine(kappa);
                }
            }
        }
    }
}
