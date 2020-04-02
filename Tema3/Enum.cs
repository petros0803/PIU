using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
    internal enum FacultySpecialization
    {
        None,
        Calculatoare,
        Automatica,
        Electronica,
        Managementul_energiei,
        Sisteme_electrice

    }
    [Flags]
    internal enum StudentProgrammingLanguages
    {
        None = 0,
        Cpp = 1 << 0,
        C = 1 << 1,
        Cs = 1 << 2,
        HTML = 1 << 3,
        CSS = 1 << 4,
        JS = 1 << 5,
        Py = 1 << 6
    }
}
