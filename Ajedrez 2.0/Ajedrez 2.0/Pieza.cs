using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    public abstract class Pieza
    {
        public char Img { get; set; }
        public char Color { get; set; }
        public Coordenada Posicion { get; set; }
        public abstract void CalcularMovimientos(Pieza [,]Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color);
    }
}
