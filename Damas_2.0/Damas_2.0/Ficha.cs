using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    class Ficha : Pieza
    {
        private int Orientacion;

        public Ficha(Jugador Jugador) : base(Jugador)
        {
        }

        public override List<Coordenada> CalcularMov(Tablero Tablero)
        {
            List<Coordenada> PosiblesMovimientos = new List<Coordenada>();

            if (Icono == 'O')
                Orientacion = -1;
            else if (Icono == 'X')
                Orientacion = 1;

            if (PosicionInicial.Y + 1 <= Tablero.Ancho - 1 && PosicionInicial.X + Orientacion <= Tablero.Alto)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicial.X + Orientacion, PosicionInicial.Y + 1);
                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·')
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else { }
            }

            if (PosicionInicial.Y - 1 >= 0 && PosicionInicial.X + Orientacion <= Tablero.Alto)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicial.X + Orientacion, PosicionInicial.Y - 1);
                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·')
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else { }       
            }
            return PosiblesMovimientos;
        }
    }
}
