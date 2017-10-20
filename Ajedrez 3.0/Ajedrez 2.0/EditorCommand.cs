using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    public abstract class EditorCommand
    {
        public abstract void Ejecutar();
        public abstract void Revertir();
    }
}
