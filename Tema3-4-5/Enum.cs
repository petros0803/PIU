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
        Cpp = 1 << 0,     // 1
        C = 1 << 1,      // 2
        Cs = 1 << 2,    // 4
        HTML = 1 << 3, // 8
        CSS = 1 << 4, // 16
        JS = 1 << 5, // 32
        Py = 1 << 6 // 64
    }
}
