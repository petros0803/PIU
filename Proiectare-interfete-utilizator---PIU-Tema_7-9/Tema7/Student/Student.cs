using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLB
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int StudyYear { get; private set; }
        public List<double> Grades { get; set; }
        public double Average { get; set; }
        public FacultySpecialization Specialization { get; private set; }
        public StudentProgrammingLanguages ProgrammingLanguages { get; set; }

        public Student() {
            Id = Guid.NewGuid();
            FirstName = LastName = string.Empty;
            StudyYear = 0;
            Grades = new List<double>();
            Specialization = FacultySpecialization.None;
            ProgrammingLanguages = StudentProgrammingLanguages.None;
        }

        public Student(string firstName, string lastName, int studyYear, string grades, 
            FacultySpecialization specialization, StudentProgrammingLanguages programmingLanguages)
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

        public Student(Guid id, string firstName, string lastName, int studyYear, string grades,
    FacultySpecialization specialization, StudentProgrammingLanguages programmingLanguages)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StudyYear = studyYear;
            Grades = new List<double>();
            GradesConversion(grades);
            Specialization = specialization;
            ProgrammingLanguages = programmingLanguages;
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
        public void AverageGrades()
        {
            Average = Grades.Average();
        }

        public void UpdateThisStudent(string firstName, string lastName, int studyYear, string grades,
    FacultySpecialization specialization, StudentProgrammingLanguages programmingLanguages)
        {
            FirstName = firstName;
            LastName = lastName;
            StudyYear = studyYear;
            Grades = new List<double>();
            GradesConversion(grades);
            Specialization = specialization;
            ProgrammingLanguages = programmingLanguages;
        }

        public override string ToString()
        {
            return string.Format("***Studentul cu id: {0}***\n" +
                                 "-->Nume: {1} {2}.\n" +
                                 "-->Student in anul: {3}.\n" +
                                 "-->Specializarea: {4}.\n" +
                                 "-->Note: {5}.\n"+
                                 "-->Media: {6:F2}\n" +
                                 "-->Limbajele preferate: {7}.\n",
                                 Id, FirstName, LastName, StudyYear, Specialization, String.Join(", ", Grades), Average, ProgrammingLanguages);
        }
    }
}
