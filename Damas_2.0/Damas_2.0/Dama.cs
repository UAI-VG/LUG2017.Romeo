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

        public void CalcularMovs(Coordenada PosicionInicio, Tablero Tablero, int Orientacion, int Lado)
        {
            if (PosicionInicio.Y + 1 <= Tablero.Ancho - 1 && PosicionInicio.X + Orientacion <= Tablero.Alto && !Final)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicio.X + Orientacion, PosicionInicio.Y + Lado);

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y + Lado].Icono == '·')
                    {
                        Coordenada Destino = new Coordenada(Movimiento.X + Orientacion, Movimiento.Y + Lado);
                        Capturadas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Destino.PiezasComidas = Capturadas;
                        PosiblesMovimientos.Add(Destino);
                        Capturo = true;
                        CalcularMovs(Destino, Tablero, Orientacion, Lado);
                    }
                }
            }
        }

        public override List<Coordenada> CalcularMovimientos(Coordenada PosicionInicio, Tablero Tablero)
        {
            for (int i = 1; i < Tablero.Alto; i++)
            {
             //Abajo Derecha
                try
                {
                    if (Tablero.Grilla[PosicionInicial.X + i, PosicionInicial.Y + i].Icono == '·')
                    {
                        Coordenada Movimiento = new Coordenada(PosicionInicial.X + i, PosicionInicial.Y + i);
                        PosiblesMovimientos.Add(Movimiento);
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y + i].Icono != '·' && Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y + i].Icono == Icono)
                    {
                        break;
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y + i].Icono != '·' && Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y + i].Icono != Icono)
                    {                      
                        Coordenada Inicio = new Coordenada(PosicionInicio.X + i - 1, PosicionInicio.Y + i - 1);
                        CalcularMovs(Inicio, Tablero, 1, 1);
                        break;
                    }
                }
                catch (IndexOutOfRangeException) { }
                
                // Abajo Izquierda
                try
                {
                    if (Tablero.Grilla[PosicionInicial.X + i, PosicionInicial.Y - i].Icono == '·')
                    {
                        Coordenada Movimiento = new Coordenada(PosicionInicial.X + i, PosicionInicial.Y - i);
                        PosiblesMovimientos.Add(Movimiento);
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y - i].Icono != '·' && Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y - i].Icono == Icono)
                    {
                        break;
                    }
                    else if (Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y - i].Icono != '·' && Tablero.Grilla[PosicionInicio.X + i, PosicionInicio.Y - i].Icono != Icono)
                    {
                        Coordenada Inicio = new Coordenada(PosicionInicio.X + i - 1, PosicionInicio.Y - i + 1);
                        CalcularMovs(Inicio, Tablero, 1, - 1);
                        break;
                    }
                }
                catch (IndexOutOfRangeException) { }

                // Arriba Derecha
                try
                {
                    if (Tablero.Grilla[PosicionInicial.X - i, PosicionInicial.Y + i].Icono == '·')
                    {
                        Coordenada Movimiento = new Coordenada(PosicionInicial.X - i, PosicionInicial.Y + i);
                        PosiblesMovimientos.Add(Movimiento);
                    }
                    else if (Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y + i].Icono != '·' && Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y + i].Icono == Icono)
                    {
                        break;
                    }
                    else if (Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y + i].Icono != '·' && Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y + i].Icono != Icono)
                    {
                        Coordenada Inicio = new Coordenada(PosicionInicio.X - i + 1, PosicionInicio.Y + i - 1);
                        CalcularMovs(Inicio, Tablero, -1, 1);
                        break;
                    }
                }
                catch (IndexOutOfRangeException) { }


                // Arriba Izquierda
                try
                {
                    if (Tablero.Grilla[PosicionInicial.X - i, PosicionInicial.Y - i].Icono == '·')
                    {
                        Coordenada Movimiento = new Coordenada(PosicionInicial.X - i, PosicionInicial.Y - i);
                        PosiblesMovimientos.Add(Movimiento);
                    }
                    else if (Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y - i].Icono != '·' && Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y - i].Icono == Icono)
                    {
                        break;
                    }
                    else if (Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y - i].Icono != '·' && Tablero.Grilla[PosicionInicio.X - i, PosicionInicio.Y - i].Icono != Icono)
                    {
                        Coordenada Inicio = new Coordenada(PosicionInicio.X - i + 1, PosicionInicio.Y - i + 1);
                        CalcularMovs(Inicio, Tablero, -1, -1);
                        break;
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
