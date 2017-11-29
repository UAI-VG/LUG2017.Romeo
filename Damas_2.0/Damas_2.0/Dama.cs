using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{

    class Dama : Pieza
    {
        private int Orientacion;
        private List<Coordenada> PosiblesMovimientos { get; set; } = new List<Coordenada>();
        private List<Pieza> Capturadas { get; set; } = new List<Pieza>();
        private bool Capturo = false;
        private bool Final = false;

        public Dama(Jugador Jugador) : base(Jugador)
        {
        }

        public void CalcularMovs(Coordenada PosicionInicio, Tablero Tablero)
        {
            if (Icono == 'O')
                Orientacion = -1;
            else if (Icono == 'X')
                Orientacion = 1;

            if (PosicionInicio.Y + 1 <= Tablero.Ancho - 1 && PosicionInicio.X + Orientacion <= Tablero.Alto && !Final)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicio.X + Orientacion, PosicionInicio.Y + 1);

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y + 1].Icono == '·')
                    {
                        Coordenada Destino = new Coordenada(Movimiento.X + Orientacion, Movimiento.Y + 1);
                        Capturadas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Destino.PiezasComidas = Capturadas;
                        PosiblesMovimientos.Add(Destino);
                        Capturo = true;
                        CalcularMovs(Destino, Tablero);
                    }
                }
            }
        }

        public override List<Coordenada> CalcularMovimientos(Coordenada PosicionInicio, Tablero Tablero)
        {
            int VarX1 = 1;
            int VarX2 = 1;
            int VarX3 = 1;
            int VarX4 = 1;
            int VarY1 = 1;
            int VarY2 = 1;
            int VarY3 = 1;
            int VarY4 = 1;

            bool BlockDR = false;
            bool BlockUR = false;
            bool BlockDL = false;
            bool BlockUL = false;

            for (int i = 0; i < Tablero.Alto; i++)
            {
                try
                {
                    if (Tablero.Grilla[PosicionInicial.X + VarX1, PosicionInicial.Y + VarY1].Icono == '·' && !BlockDR)
                    {
                        Coordenada Movimiento = new Coordenada(PosicionInicial.X + i, PosicionInicial.Y + i);
                        PosiblesMovimientos.Add(Movimiento);
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + VarX1, PosicionInicio.Y + VarY1].Icono != '·' && Tablero.Grilla[PosicionInicio.X + VarX1, PosicionInicio.Y + VarY1].Icono == Icono && !BlockDR)
                    {
                        BlockDR = true;
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + VarX1, PosicionInicio.Y + VarY1].Icono != '·' && Tablero.Grilla[PosicionInicio.X + VarX1, PosicionInicio.Y + VarY1].Icono != Icono && !BlockDR)
                    {
                        BlockDR = true;
                        Coordenada Inicio = new Coordenada(PosicionInicio.X + VarX1 - 1, PosicionInicio.Y + VarY1 - 1);
                        CalcularMovs(Inicio, Tablero);
                    }
                }
                catch (IndexOutOfRangeException) { }      
            }

            return PosiblesMovimientos;
        }

        public override List<Coordenada> CalcularMov(Tablero Tablero)
        {
            throw new NotImplementedException();
        }
    }
}
