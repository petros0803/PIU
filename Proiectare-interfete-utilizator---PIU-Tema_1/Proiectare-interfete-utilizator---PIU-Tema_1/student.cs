using System;

namespace Tema_PIU
{

	public class student
	{
		string name;
		int grade, studyYear;

		public student()
		{
			name = string.Empty;
			grade = -1;
			studyYear = -1;
		}

		public student(string _name, int _grade)
		{
			name = _name;
			grade = _grade;
		}

		public void SetStudentName(string _name)
        {
			name = _name;
        }

		public bool SetStudentGrade(int _grade)
		{
			if (_grade > 10 || _grade < 1)
			{
				Console.WriteLine("Nota Studentului nu este posibila: ");
				return false;
			}

			grade = _grade;
			return true;
		}
		public bool SetStudentStudyYear(int _studyYear)
		{
			if (_studyYear > 4 || _studyYear < 1)
			{
				Console.WriteLine("Anul de studiu setat este incorect: ");
				return false;
			}
			studyYear = _studyYear;
			return true;
		}

		public string GetStudentName()
		{
			return name;
		}
		public int GetStudentGrade()
		{
			return grade;
		}
		public int GetStudentStudyYear()
		{
			return studyYear;
		}

		public string DisplayStudent()
        {
			grade = GetStudentGrade();
			if (grade >= 5)
				return string.Format("Studentul {0}, student in anul {1}, nota: {2}, PROMOVAT", GetStudentName(), GetStudentStudyYear(), grade);
			else
				return string.Format("Studentul {0}, student in anul {1}, nota: {2}, NEPROMOVAT", GetStudentName(), GetStudentStudyYear(), grade);
		}
	}
}