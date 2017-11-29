using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    [Serializable]
    public class Jugador
    {
        public List<Pieza> Piezas { get; set; } = new List<Pieza>();
        public Tablero Tablero { get; set; }
    }
}
