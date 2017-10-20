using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class ComandoMover : EditorCommand
    {
        Pieza p;
        Coordenada PosInicial;
        Coordenada PosFinal;
        Pieza[,] Tablero;
        public List<Coordenada> ListaMovBlancos;
        public List<Coordenada> ListaMovNegros;

        public ComandoMover(Pieza p, Coordenada PosInicial, Coordenada PosFinal, Pieza[,]Tablero, List<Coordenada>ListaBlanco, List<Coordenada>ListaNegros)
        {
            this.p = p;
            this.PosInicial = PosInicial;
            this.PosFinal = PosFinal;
            this.Tablero = Tablero;
            p.CalcularMovimientos(Tablero, PosInicial, ListaBlanco, ListaNegros, p.Color);
            ListaMovBlancos = ListaBlanco;
            ListaMovNegros = ListaNegros;
        }

        public override void Ejecutar()
        {
            if (p.Color == 'B')
            {
                foreach (Coordenada c in ListaMovBlancos)
                {
                    if (c.X == PosFinal.X && c.Y == PosFinal.Y)
                    {
                        Tablero[PosFinal.X, PosFinal.Y] = p;
                        Tablero[PosInicial.X, PosInicial.Y] = new PiezaVacia();
                    }
                }
            }
            else if (p.Color == 'N')
            {
                foreach (Coordenada c in ListaMovNegros)
                {
                    if (c.X == PosFinal.X && c.Y == PosFinal.Y)
                    {
                        Tablero[PosFinal.X, PosFinal.Y] = p;
                        Tablero[PosInicial.X, PosInicial.Y] = new PiezaVacia();
                    }
                }
            }

        }

        public override void Revertir()
        {
            Tablero[PosInicial.X, PosInicial.Y] = p;
            Tablero[PosFinal.X, PosFinal.Y] = new PiezaVacia();
        }
    }
}
