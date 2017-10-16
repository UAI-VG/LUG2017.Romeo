using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    public class Coordenada
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Pieza> PiezasComidas { get; set; } = new List<Pieza>();

        public Coordenada(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
