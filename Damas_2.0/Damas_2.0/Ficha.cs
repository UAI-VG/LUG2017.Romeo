﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    class Ficha : Pieza
    {
        private int Orientacion;
        private Tablero TableroClonado;
        private Coordenada NuevaPosInicial;

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
                Coordenada NuevoMovimiento;

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·')
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y + 1].Icono == '·')
                    {
                        Movimiento.PiezasComidas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Movimiento.X = PosicionInicial.X + Orientacion * 2;
                        Movimiento.Y = PosicionInicial.Y + 2;
                        PosiblesMovimientos.Add(Movimiento);

                        TableroClonado = new Tablero(Tablero.Alto, Tablero.Ancho);
                        TableroClonado.Grilla = new Pieza[Tablero.Alto,Tablero.Ancho];
                        TableroClonado = (Tablero)Tablero.Clone();

                    /*    for (int f = 0; f < Tablero.Alto; f++)
                        {
                            for (int c = 0; c < Tablero.Alto; c++)
                            {
                                TableroClonado.Grilla[f, c] = new Ficha(Tablero.Grilla[f,c].Jugador);
                                TableroClonado.Grilla[f, c].PosicionInicial = Tablero.Grilla[f, c].PosicionInicial;
                            }
                        }
                        */

                        TableroClonado.MoverPieza(this, Movimiento);

                        NuevaPosInicial = new Coordenada(Movimiento.X, Movimiento.Y);
                        NuevoMovimiento = new Coordenada(CalcularNuevoMov(TableroClonado).X, CalcularNuevoMov(TableroClonado).Y);

                        if (NuevoMovimiento != null)
                        PosiblesMovimientos.Add(NuevoMovimiento);
                    }
                }
            }

            if (PosicionInicial.Y - 1 >= 0 && PosicionInicial.X + Orientacion <= Tablero.Alto)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicial.X + Orientacion, PosicionInicial.Y - 1);
                Coordenada NuevoMovimiento;

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·')
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y - 1].Icono == '·')
                    {
                        Movimiento.PiezasComidas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Movimiento.X = PosicionInicial.X + Orientacion * 2;
                        Movimiento.Y = PosicionInicial.Y - 2;
                        PosiblesMovimientos.Add(Movimiento);

                        TableroClonado = new Tablero(Tablero.Alto, Tablero.Ancho);
                        TableroClonado.Grilla = new Pieza[Tablero.Alto, Tablero.Ancho];
                        TableroClonado = (Tablero)Tablero.Clone();

                        /*   for (int f = 0; f < Tablero.Alto; f++)
                           {
                               for (int c = 0; c < Tablero.Alto; c++)
                               {
                                   TableroClonado.Grilla[f, c] = new Ficha(Tablero.Grilla[f, c].Jugador);
                                   TableroClonado.Grilla[f, c].PosicionInicial = Tablero.Grilla[f, c].PosicionInicial;
                               }
                           }
                           */

                        TableroClonado.MoverPieza(this, Movimiento);

                        NuevaPosInicial = new Coordenada(Movimiento.X, Movimiento.Y);
                        NuevoMovimiento = new Coordenada(CalcularNuevoMov2(TableroClonado).X, CalcularNuevoMov2(TableroClonado).Y);

                        Movimiento = CalcularNuevoMov2(TableroClonado);

                        if (NuevoMovimiento != null)
                            PosiblesMovimientos.Add(NuevoMovimiento);
                    }
                }

            }
            return PosiblesMovimientos;
        }



        public Coordenada CalcularNuevoMov(Tablero Tablero)
        {
            Coordenada NuevoMovimiento = new Coordenada(NuevaPosInicial.X + Orientacion, NuevaPosInicial.Y + 1);

            if (Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y].Icono != Icono && Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y].Icono != '·')
            {
                if (Tablero.Grilla[NuevoMovimiento.X + Orientacion, NuevoMovimiento.Y + 1].Icono == '·')
                {
                    NuevoMovimiento.PiezasComidas.Add(Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y]);
                    NuevoMovimiento.X = NuevaPosInicial.X + Orientacion * 2;
                    NuevoMovimiento.Y = NuevaPosInicial.Y + 2;              
                }
                else
                {
                    NuevoMovimiento = null;
                }
            }
            return NuevoMovimiento;
        }


        public Coordenada CalcularNuevoMov2(Tablero Tablero)
        {
            Coordenada NuevoMovimiento = new Coordenada(NuevaPosInicial.X + Orientacion, NuevaPosInicial.Y - 1);

            if (Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y].Icono != Icono && Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y].Icono != '·')
            {
                if (Tablero.Grilla[NuevoMovimiento.X + Orientacion, NuevoMovimiento.Y - 1].Icono == '·')
                {
                    NuevoMovimiento.PiezasComidas.Add(Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y]);
                    NuevoMovimiento.X = NuevaPosInicial.X + Orientacion * 2;
                    NuevoMovimiento.Y = NuevaPosInicial.Y - 2; 
                }
                else
                {
                    NuevoMovimiento = null;
                }
            }
            return NuevoMovimiento;
        }
    }
}
