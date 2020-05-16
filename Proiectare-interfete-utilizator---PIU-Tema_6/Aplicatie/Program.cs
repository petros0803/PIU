using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using LibrarieModele;
using NivelAccesDate;
using System.Text.RegularExpressions;
using System.IO;

namespace Aplicatie
{
    class Program
    {
        static void Main(string[] args)
        {

            Formular form1 = new Formular();
            form1.Show();
            Application.Run();
        }
    }

    public class Formular : Form
    {
        IStocareData adminStudenti = StocareFactory.GetAdministratorStocare();

        private Label lblNume;
        private Label lblPrenume;
        private Label lblNote;
        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtNote;
        private Label lblInfo;
        private Button btnAdaugare;

        private const int LATIME_CONTROL = 150;
        private const int INALTIME_CONTROL = 20;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        private const int LUNGIME_MAX = 15;
        private const int LUNGIME_MIN = 3;

        public Formular()
        {
            this.Size = new System.Drawing.Size(1000, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Administrare Studenti";

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume: ";
            lblNume.BackColor = Color.Aqua;
            this.Controls.Add(lblNume);

            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume: ";
            lblPrenume.Top = DIMENSIUNE_PAS_Y;
            lblPrenume.BackColor = Color.Aqua;
            this.Controls.Add(lblPrenume);

            lblNote = new Label();
            lblNote.Width = LATIME_CONTROL;
            lblNote.Text = "Note: ";
            lblNote.Top = DIMENSIUNE_PAS_Y * 2;
            lblNote.BackColor = Color.Aqua;
            this.Controls.Add(lblNote);

            lblInfo = new Label();
            lblInfo.Width = LATIME_CONTROL * 3;
            lblInfo.Text = string.Empty;
            lblInfo.Top = DIMENSIUNE_PAS_Y * 4;
            lblInfo.Height = INALTIME_CONTROL * 2;
            lblInfo.BackColor = Color.Aqua;
            this.Controls.Add(lblInfo);



            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 0);
            this.Controls.Add(txtNume);


            txtPrenume = new TextBox();
            txtPrenume.Width = LATIME_CONTROL;
            txtPrenume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtPrenume);

            txtNote = new TextBox();
            txtNote.Width = LATIME_CONTROL;
            txtNote.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 2);
            this.Controls.Add(txtNote);

            btnAdaugare = new Button();
            btnAdaugare.Width = LATIME_CONTROL;
            btnAdaugare.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            btnAdaugare.Text = "Adaugati student";
            this.Controls.Add(btnAdaugare);


            btnAdaugare.Click += OnButtonAdaugaClicked;
            this.Controls.Add(btnAdaugare);
        }

        private void OnButtonAdaugaClicked(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("E:/Facultate/C#/Tema 6/Aplicatie/text.txt");
            bool ok = true;

            lblNume.ForeColor = Color.Black;
            lblPrenume.ForeColor = Color.Black;
            lblNote.ForeColor = Color.Black;

            bool validare = Validare(ok);

            if (validare == true )
            {
                Student s = new Student(txtNume.Text, txtPrenume.Text);
                s.SetNote(txtNote.Text);

                lblInfo.Text = s.ConversieLaSir();
                adminStudenti.AddStudent(s);
                writer.WriteLine(s.ConversieLaSir_PentruFisier());
                writer.Close();
            }
        }

        private bool Validare(bool ok)
        {
            if (txtNume.Text == string.Empty || txtNume.Text.Length > LUNGIME_MAX || txtNume.Text.Length < LUNGIME_MIN)
            {
                lblNume.ForeColor = Color.Red;
                ok = false;
            }
            if (txtPrenume.Text == string.Empty || txtPrenume.Text.Length > LUNGIME_MAX || txtPrenume.Text.Length < LUNGIME_MIN)
            {
                lblPrenume.ForeColor = Color.Red;
                ok = false;
            }
            if (!IsGradeValid(txtNote.Text))
            {
                lblNote.ForeColor = Color.Red;
                ok = false;
            }
            return ok;
        }

        public static bool IsGradeValid(string grades)
        {
            return new Regex(@"^([0-9]+ )*[0-9]+$").IsMatch(grades);
        }
    }

}


