using StudentLB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WF
{
    public partial class Form1 : Form
    {
        readonly int LUNGIME_MAX = 15;
        readonly int LUNGIME_MIN = 3;

        private Student selectedStudent;

        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            buttonModifica.Hide();
            comboBoxSpecializare.DataSource = Enum.GetValues(typeof(FacultySpecialization));
            listboxLimbajeDeProgramare.DataSource = Enum.GetValues(typeof(StudentProgrammingLanguages));
            listboxLimbajeDeProgramare.SelectionMode = SelectionMode.MultiSimple;

            List<Student> students = new List<Student>();
            readFromFile();
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            labelNume.ForeColor = Color.Black;
            labelPrenume.ForeColor = Color.Black;
            labelNote.ForeColor = Color.Black;

            if (Validare())
            {
                var specialization = (FacultySpecialization)comboBoxSpecializare.SelectedIndex;

                var languages = listboxLimbajeDeProgramare.SelectedIndices;
                var temp = StudentProgrammingLanguages.None;

                foreach (int elem in languages)
                {
                    if (temp == StudentProgrammingLanguages.None)
                    {
                        temp = (StudentProgrammingLanguages)(elem);
                    }
                    else
                    {
                        temp = temp | (StudentProgrammingLanguages)(1 << elem);
                    }
                }
                Debug.WriteLine(temp);
                Student Stud = new Student(textBoxNume.Text, textBoxPrenume.Text, Int32.Parse(textBoxAnStudiu.Text), textBoxNote.Text,
                     specialization, temp);
                using (StreamWriter sw = new StreamWriter("C:/Users/Bobo/Documents/GitHub/PIU/Proiectare-interfete-utilizator---PIU-Tema_7/Tema7/TextFiles/Students.txt"))
                {
                    sw.WriteLine(Stud.ToString());
                }
                    labelAdaugaStudent.Text = Stud.ToString();
            }
        }

        private bool Validare()
        {
            bool ok = true;

            if (textBoxNume.Text == string.Empty || textBoxNume.Text.Length > LUNGIME_MAX || textBoxNume.Text.Length < LUNGIME_MIN)
            {
                labelNume.ForeColor = Color.Red;
                ok = false;
            }
            if (textBoxPrenume.Text == string.Empty || textBoxPrenume.Text.Length > LUNGIME_MAX || textBoxPrenume.Text.Length < LUNGIME_MIN)
            {
                labelPrenume.ForeColor = Color.Red;
                ok = false;
            }
            if (!IsGradeValid(textBoxNote.Text))
            {
                labelNote.ForeColor = Color.Red;
                ok = false;
            }
            return ok;
        }

        private bool ValidareCautare()
        {
            bool ok = true;

            if (textBoxNume.Text == string.Empty || textBoxNume.Text.Length > LUNGIME_MAX || textBoxNume.Text.Length < LUNGIME_MIN)
            {
                labelNume.ForeColor = Color.Red;
                ok = false;
            }
            if (textBoxPrenume.Text == string.Empty || textBoxPrenume.Text.Length > LUNGIME_MAX || textBoxPrenume.Text.Length < LUNGIME_MIN)
            {
                labelPrenume.ForeColor = Color.Red;
                ok = false;
            }

            return ok;
        }

        public static bool IsGradeValid(string grades)
        {
            return new Regex(@"^([0-9]+ )*[0-9]+$").IsMatch(grades);
        }

        private void comboBoxSpecializare_SelectedIndexChanged(object sender, EventArgs e)
        { 
            FacultySpecialization specialization;
            Enum.TryParse<FacultySpecialization>(comboBoxSpecializare.SelectedValue.ToString(), out specialization);
        }

        private void listboxLimbajeDeProgramare_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            labelNume.ForeColor = Color.Black;
            labelPrenume.ForeColor = Color.Black;
            labelNote.ForeColor = Color.Black;

            if (ValidareCautare())
            {
                foreach (var stud in students)
                {
                    if(stud.FirstName == textBoxPrenume.Text && stud.LastName == textBoxNume.Text)
                    {
                        labelFoundStudent.Text = stud.ToString();

                        textBoxNume.Text = stud.LastName;
                        textBoxPrenume.Text = stud.FirstName;
                        textBoxNote.Text = String.Join(" ", stud.Grades);
                        textBoxAnStudiu.Text = stud.StudyYear.ToString();

                        buttonAdauga.Hide();
                        buttonCauta.Hide();
                        buttonModifica.Show();

                        selectedStudent = stud;
                        return;
                    }
                }
                labelFoundStudent.Text = "STUDENTUL CAUTAT NU ESTE GASIT";
            }
        }

        private void readFromFile()
        {
            using (StreamReader sr = new StreamReader("C:/Users/Bobo/Documents/GitHub/PIU/Proiectare-interfete-utilizator---PIU-Tema_7/Tema7/TextFiles/Students.txt"))
            {
                string line = string.Empty;

                while (line != null)
                {
                    string firstName = string.Empty, lastName = string.Empty, grades = string.Empty;
                    Guid studentID = Guid.Empty;
                    int studyYear = 0, index = 0;
                    double average = 0.0;
                    FacultySpecialization specializare = FacultySpecialization.None;
                    var languages = StudentProgrammingLanguages.None;

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
                                if (firstName == string.Empty)
                                {
                                    firstName = elem;
                                }
                                else
                                {
                                    firstName = firstName + ' ' + elem;
                                }
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
                        {
                            foreach (var elem in elems.Skip(1))
                            {
                                if (grades == String.Empty)
                                {
                                    grades = elem.Trim(new Char[] { ' ', '*', '.', ',' });
                                }
                                else
                                {
                                    grades = grades + ' ' + elem.Trim(new Char[] { ' ', '*', '.', ',' });
                                }
                            }
                        }
                        else if (index == 5)
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
                    students.Add(new Student(studentID, firstName, lastName, studyYear, grades,  specializare, languages));
                }
            }
            //foreach (var stud in students)
            //{
            //    labelAllStudents.Text += '\n' + stud.ToString();
            //}
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            buttonAdauga.Show();
            buttonCauta.Show();
            buttonModifica.Hide();
            labelFoundStudent.Hide();

            if (Validare())
            {
                var specialization = (FacultySpecialization)comboBoxSpecializare.SelectedIndex;

                var languages = listboxLimbajeDeProgramare.SelectedIndices;
                var temp = StudentProgrammingLanguages.None;

                foreach (int elem in languages)
                {
                    if (temp == StudentProgrammingLanguages.None)
                    {
                        temp = (StudentProgrammingLanguages)(elem);
                    }
                    else
                    {
                        temp = temp | (StudentProgrammingLanguages)(1 << elem);
                    }
                }
                Debug.WriteLine(temp);
                selectedStudent.UpdateThisStudent(textBoxPrenume.Text, textBoxNume.Text, Int32.Parse(textBoxAnStudiu.Text), textBoxNote.Text,
                    specialization, temp);

                labelAdaugaStudent.Text = selectedStudent.ToString();

                using (StreamWriter sw = new StreamWriter("C:/Users/Bobo/Documents/GitHub/PIU/Proiectare-interfete-utilizator---PIU-Tema_7/Tema7/TextFiles/Students.txt"))
                {
                    foreach (var stud in students)
                        sw.WriteLine(stud.ToString());
                }
            }
        }
    }
}

