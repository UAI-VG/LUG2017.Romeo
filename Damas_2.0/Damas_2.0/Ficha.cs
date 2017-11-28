using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    [Serializable]
    class Ficha : Pieza
    {
        private int Orientacion;

        private Tablero TableroClonado;
        private Coordenada NuevaPosInicial;
        private List<Coordenada> PosiblesMovimientos { get; set; } = new List<Coordenada>();
        private List<Pieza> Capturadas { get; set; } = new List<Pieza>();
        bool Capturo = false;

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
                        TableroClonado.Grilla = new Pieza[Tablero.Alto, Tablero.Ancho];
                        TableroClonado = TableroClonado.Clonador.Clonar(Tablero);

                        TableroClonado.MoverPieza(this, Movimiento);

                        NuevaPosInicial = new Coordenada(Movimiento.X, Movimiento.Y);
                        NuevoMovimiento = new Coordenada(CalcularNuevoMov(TableroClonado).X, CalcularNuevoMov(TableroClonado).Y);
                        NuevoMovimiento.PiezasComidas = CalcularNuevoMov(TableroClonado).PiezasComidas;
                        NuevoMovimiento.PiezasComidas.Add(Movimiento.PiezasComidas[0]);
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
                        TableroClonado = TableroClonado.Clonador.Clonar(Tablero);

                        TableroClonado.MoverPieza(this, Movimiento);

                        NuevaPosInicial = new Coordenada(Movimiento.X, Movimiento.Y);
                        NuevoMovimiento = new Coordenada(CalcularNuevoMov2(TableroClonado).X, CalcularNuevoMov2(TableroClonado).Y);
                        NuevoMovimiento.PiezasComidas = CalcularNuevoMov2(TableroClonado).PiezasComidas;
                        NuevoMovimiento.PiezasComidas.Add(Movimiento.PiezasComidas[0]);
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
                    NuevoMovimiento.PiezasComidas.Add(Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y]);
                    NuevoMovimiento.X = NuevaPosInicial.X + Orientacion * 2;
                    NuevoMovimiento.Y = NuevaPosInicial.Y + 2;
                }
            }
            else
            {
                NuevoMovimiento = null;
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
                    NuevoMovimiento.PiezasComidas.Add(Tablero.Grilla[NuevoMovimiento.X, NuevoMovimiento.Y]);
                    NuevoMovimiento.X = NuevaPosInicial.X + Orientacion * 2;
                    NuevoMovimiento.Y = NuevaPosInicial.Y - 2;
                }
            }
            else
            {
                NuevoMovimiento = null;
            }
            return NuevoMovimiento;
        }

        public override List<Coordenada> CalcularMovimientos(Coordenada PosicionInicio, Tablero Tablero)
        {
            if (Icono == 'O')
                Orientacion = -1;
            else if (Icono == 'X')
                Orientacion = 1;

            //------------------------------------------------------------------------------------------------------------------------------------------------
            //LADO DERECHO

            if (PosicionInicio.Y + 1 <= Tablero.Ancho - 1 && PosicionInicio.X + Orientacion <= Tablero.Alto)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicio.X + Orientacion, PosicionInicio.Y + 1);

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·' && !Capturo)
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y + 1].Icono == '·')
                    {
                        Coordenada Destino = new Coordenada(Movimiento.X + Orientacion, Movimiento.Y + 1);
                        Capturadas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Destino.PiezasComidas = Capturadas;
                        PosiblesMovimientos.Add(Destino);
                        Capturo = true;
                        CalcularMovimientos(Destino, Tablero);      
                    }
                }
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------------------------------------------------
            //LADO IZQUIERDO

            if (PosicionInicio.Y - 1 <= Tablero.Ancho - 1 && PosicionInicio.X + Orientacion <= Tablero.Alto)
            {
                Coordenada Movimiento = new Coordenada(PosicionInicio.X + Orientacion, PosicionInicio.Y - 1);

                if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono == '·' && !Capturo)
                {
                    PosiblesMovimientos.Add(Movimiento);
                }
                else if (Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != Icono && Tablero.Grilla[Movimiento.X, Movimiento.Y].Icono != '·')
                {
                    if (Tablero.Grilla[Movimiento.X + Orientacion, Movimiento.Y - 1].Icono == '·')
                    {
                        Coordenada Destino = new Coordenada(Movimiento.X + Orientacion, Movimiento.Y - 1);
                        Capturadas.Add(Tablero.Grilla[Movimiento.X, Movimiento.Y]);
                        Destino.PiezasComidas = Capturadas;
                        PosiblesMovimientos.Add(Destino);
                        Capturo = true;
                        CalcularMovimientos(Destino, Tablero);
                    }
                }
            }
            return PosiblesMovimientos;
        }
    }
}
