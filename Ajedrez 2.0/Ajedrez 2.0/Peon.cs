using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Peon : Pieza
    {
        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            if (Color == 'N')
            {
                try
                {
                    if (Coordenadas.Y + 1 <= Tablero.GetLength(1) &&
                       Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Color != Color && Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Img != '*')
                    {
                        Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Img = 'X';
                    }

                    if (Coordenadas.Y - 1 >= 0 &&
                        Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Color != Color && Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Img != '*')
                    {
                        Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Img = 'X';
                    }

                    if (Tablero[Coordenadas.X + 1, Coordenadas.Y].Img == '*' || Tablero[Coordenadas.X + 1, Coordenadas.Y].Color != this.Color)
                        Tablero[Coordenadas.X + 1, Coordenadas.Y].Img = 'X';

                    if (Coordenadas.X == 1)
                        Tablero[Coordenadas.X + 2, Coordenadas.Y].Img = 'X';

                }
                catch (IndexOutOfRangeException) { }
            }
            else if (Color == 'B')
            {
                try
                {
                    if (Coordenadas.Y + 1 <= Tablero.GetLength(1) &&
                         Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Color != Color && Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Img != '*')
                    {
                        Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Img = 'X';
                    }

                    if (Coordenadas.Y - 1 >= 0 &&
                        Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Color != Color && Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Img != '*')
                    {
                        Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Img = 'X';
                    }

                    if (Tablero[Coordenadas.X - 1, Coordenadas.Y].Img == '*' || Tablero[Coordenadas.X - 1, Coordenadas.Y].Color != this.Color)
                        Tablero[Coordenadas.X - 1, Coordenadas.Y].Img = 'X';

                    if (Coordenadas.X == 6)
                        Tablero[Coordenadas.X - 2, Coordenadas.Y].Img = 'X';

                }
                catch (IndexOutOfRangeException) { }
            }

            Tablero[Coordenadas.X, Coordenadas.Y].Img = 'P';
            Console.Clear();
            Console.WriteLine("  1 2 3 4 5 6 7 8");
            int var = 0;
            string letras = "ABCDEFGH";
            for (int f = 0; f < 8; f++)
            {
                Console.Write(letras[var].ToString() + " ");
                var++;
                for (int c = 0; c < 8; c++)
                {
                    if (Tablero[f, c].Img == 'X')
                    {
                        Coordenada MovPos = new Coordenada(f,c);
                      /*  MovPos.X = f;
                        MovPos.Y = c;
                        */
                        if (Color == 'B')
                        {
                            ListaBlanca.Add(MovPos);
                        }
                        else if (Color == 'N')
                        {
                            ListaNegra.Add(MovPos);
                        }
                    }
                    Console.Write(Tablero[f, c].Img + " ");
                }
                Console.WriteLine();
            }
            Tablero[Coordenadas.X, Coordenadas.Y] = this;
        }
    }
}
