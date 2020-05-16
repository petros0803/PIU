using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareData
    {
        void AddStudent(Student s);
        Student[] GetStudenti(out int nrStudenti);

        Student GetStudent(string nume, string prenume);
    }
}
