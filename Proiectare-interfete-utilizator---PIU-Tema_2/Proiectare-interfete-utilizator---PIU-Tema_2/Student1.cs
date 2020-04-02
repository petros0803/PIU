using System;
using System.Collections.Generic;

namespace Tema_PIU
{

	public class Student
	{
		string Name { get; set; }
		int StudyYear { get; set; }
		List<int> _grades = new List<int>();

		public Student()
		{
			Name = string.Empty;
			StudyYear = -1;
		}

		public Student(string name, int studyYear)
		{
			Name = name;
			StudyYear = studyYear;
		}

		public void SetStudentGrade(string grade)
		{
			string[] words = grade.Split(' ');
			foreach (var word in words)
			{
				try
				{
					_grades.Add(Int32.Parse(word));
				}
				catch { continue; }					
			}
		}

		public void SetStudentGrade(int[] grades)
		{
			foreach (int grade in grades)
			{
				_grades.Add(grade);
			}
		}

		public string DisplayStudent()
        {
			string com = "Nu exista (Nu ati apelat metoda **SetStudentGrade**)";
			
			if(_grades != null)
			{
				com = string.Join(", ", _grades);
			}

			string studentComplet = string.Format("Studentul {0}, student in anul {1}, cu notele: {2}", Name, StudyYear, com);

			return studentComplet;
		}
	}
}