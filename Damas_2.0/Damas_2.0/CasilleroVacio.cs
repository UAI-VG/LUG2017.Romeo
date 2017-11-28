using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    [Serializable]

    class CasilleroVacio : Pieza
    {    
        public CasilleroVacio(Jugador Jugador) : base(Jugador)
        {
        }

        public override List<Coordenada> CalcularMov(Tablero Tablero)
        {
            return null;
        }

        public override List<Coordenada> CalcularMovimientos(Coordenada PosicionInicio, Tablero Tablero)
        {
            throw new NotImplementedException();
        }
    }
}
