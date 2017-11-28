using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    [Serializable]
    public abstract class Pieza
    {
        public char Icono { get; set; }
        public Jugador Jugador { get; set; }
        public Coordenada PosicionInicial { get; set; }

        public Pieza(Jugador Jugador)
        {
            this.Jugador = Jugador;
        }

        public abstract List<Coordenada> CalcularMov(Tablero Tablero);

        public abstract List<Coordenada> CalcularMovimientos(Coordenada PosicionInicio, Tablero Tablero);
    }
}
