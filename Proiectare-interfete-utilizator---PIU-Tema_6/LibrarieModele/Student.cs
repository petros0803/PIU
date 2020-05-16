using System;

namespace LibrarieModele
{
    public class Student
    {
        //constante
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        public ProgramStudiu ProgramSTD { get; set; }
        //data membra privata
        int[] note;

        //proprietati auto-implemented
        public static int IdUltimStudent { get; set; } = 0;
        public int IdStudent { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NumeComplet { get { return Nume + " " + Prenume; } }

        #region _Constructori_
        //contructor implicit
        public Student()
        {
            Nume = Prenume = string.Empty;
            IdUltimStudent++;
            IdStudent = IdUltimStudent;
        }

        //constructor1 cu parametri
        public Student(string _nume, string _prenume)
        {
            Nume = _nume;
            Prenume = _prenume;
            IdUltimStudent++;
            IdStudent = IdUltimStudent;
        }

        //constructor2 cu parametri
        public Student(string _nume, string _prenume, int[] _note)
        {
            Nume = _nume;
            Prenume = _prenume;
            note = new int[_note.Length];
            _note.CopyTo(note, 0);
            IdUltimStudent++;
            IdStudent = IdUltimStudent;
        }

        //constructor3 cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Student(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ToString()
            IdStudent = Convert.ToInt32(dateFisier[(int)CampuriStudent.ID]);
            Nume = dateFisier[(int)CampuriStudent.NUME];
            Prenume = dateFisier[(int)CampuriStudent.PRENUME];
            SetNote(dateFisier[(int)CampuriStudent.NOTE]);
            ProgramSTD = (ProgramStudiu)Enum.Parse(typeof(ProgramStudiu), dateFisier[(int)CampuriStudent.PROG_STUDIU]);
            IdUltimStudent = IdStudent;
        }

        #endregion


        //utilizare metoda statica din clasa statica
        public void SetNote(string sirNote)
        {
            string[] vectorNoteDupaSplit = sirNote.Split(' ');
            note = new int[vectorNoteDupaSplit.Length];

            int nrNote = 0;
            foreach (var nota in vectorNoteDupaSplit)
            {
                bool rezultatConversie = Int32.TryParse(nota, out note[nrNote]);
                if (rezultatConversie == SUCCES && Nota.ValideazaNota(note[nrNote]) == SUCCES)
                {
                    nrNote++;
                }
            }
            Array.Resize(ref note, nrNote);
        }
		
		public void SetNote(int[] _note)
        {
            note = new int[_note.Length];
            _note.CopyTo(note, 0);
        }
		public int[] GetNote()
        {
            // returneaza o copie a vectorului, astfel incat utilizatorii acestei librarii 
            // sa nu poata modifica continutul vectorului
            return (int[])note.Clone();
        }
        public string ConversieLaSir()
        {
            string sNote = "Nu exista (Nu ati apelat metoda setNote)";
            if (note != null)
            {
                sNote = string.Join(",", note);
            }
            string s = string.Format("Studentul cu Id: #{0} si numele: \"{1} {2}\" are notele:.... {3}", IdStudent, (Nume ?? " NECUNOSCUT "), (Prenume ?? " NECUNOSCUT "), sNote);
            return s;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string sNote = string.Empty;
            if (note != null)
            {
                sNote = string.Join(SEPARATOR_AFISARE, note);
            }
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER, IdStudent.ToString(), (Nume ?? " NECUNOSCUT "), (Prenume ?? " NECUNOSCUT "), sNote,ProgramSTD);

            return s;
        }
    }
}
