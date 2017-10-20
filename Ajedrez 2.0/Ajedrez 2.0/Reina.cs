using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Reina : Pieza
    {
        void MovAlfil(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            int VarX1 = 1;
            int VarX2 = 1;
            int VarX3 = 1;
            int VarX4 = 1;
            int VarY1 = 1;
            int VarY2 = 1;
            int VarY3 = 1;
            int VarY4 = 1;

            bool BlockUL = false; //Arriba Izquierda
            bool BlockDL = false; //Abajo Izquierda
            bool BlockUR = false; //Arriba Derecha
            bool BlockDR = false; //Abajo Derecha


            for (int i = 0; i < 7; i++)
            {
                try
                {
                    if (Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Img == '*' && BlockDR == false)
                    {
                        Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Img != '*' && Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Color == this.Color)
                    {
                        BlockDR = true;
                    }
                    else if (Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Img != '*' && Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Color != this.Color)
                    {
                        BlockDR = true;
                        Tablero[Coordenadas.X + VarX1, Coordenadas.Y + VarY1].Img = 'X';
                    }
                }
                catch (IndexOutOfRangeException) { };


                try
                {
                    if (Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Img == '*' && BlockUR == false)
                    {
                        Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Img != '*' && Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Color == this.Color)
                    {
                        BlockUR = true;
                    }
                    else if (Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Img != '*' && Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Color != this.Color)
                    {
                        BlockUR = true;
                        Tablero[Coordenadas.X - VarX2, Coordenadas.Y + VarY2].Img = 'X';
                    }
                }
                catch (IndexOutOfRangeException) { };


                try
                {
                    if (Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Img == '*' && BlockDL == false)
                    {
                        Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Img != '*' && Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Color == this.Color)
                    {
                        BlockDL = true;
                    }
                    else if (Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Img != '*' && Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Color != this.Color)
                    {
                        BlockDL = true;
                        Tablero[Coordenadas.X + VarX3, Coordenadas.Y - VarY3].Img = 'X';
                    }
                }
                catch (IndexOutOfRangeException) { };

                try
                {
                    if (Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Img == '*' && BlockUL == false)
                    {
                        Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Img != '*' && Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Color == this.Color)
                    {
                        BlockUL = true;
                    }
                    else if (Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Img != '*' && Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Color != this.Color)
                    {
                        BlockUL = true;
                        Tablero[Coordenadas.X - VarX4, Coordenadas.Y - VarY4].Img = 'X';
                    }
                }
                catch (IndexOutOfRangeException) { };

                VarX1++;
                VarY1++;

                VarX2++;
                VarY2++;

                VarX3++;
                VarY3++;

                VarX4++;
                VarY4++;
            }
        }

        void MovTorre(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            int VarX = 1;
            int VarY = 1;
            bool BlockD = false; //Abajo
            bool BlockU = false; //Arriba
            bool BlockL = false; //Izquierda
            bool BlockR = false; //Derecha


            for (int i = 0; i < 8; i++)
            {
                try
                {
                    if (Tablero[Coordenadas.X + VarX, Coordenadas.Y].Img == '*' && BlockD == false)
                    {
                        Tablero[Coordenadas.X + VarX, Coordenadas.Y].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X + VarX, Coordenadas.Y].Img != '*' && this.Color == Tablero[Coordenadas.X + VarX, Coordenadas.Y].Color)
                    {
                        BlockD = true;
                    }
                    else if (Tablero[Coordenadas.X + VarX, Coordenadas.Y].Img != '*' && this.Color != Tablero[Coordenadas.X + VarX, Coordenadas.Y].Color)
                    {
                        Tablero[Coordenadas.X + VarX, Coordenadas.Y].Img = 'X';
                        BlockD = true;
                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (Tablero[Coordenadas.X - VarX, Coordenadas.Y].Img == '*' && BlockU == false)
                    {
                        Tablero[Coordenadas.X - VarX, Coordenadas.Y].Img = 'X';
                    }
                    else
                    if (Tablero[Coordenadas.X - VarX, Coordenadas.Y].Img != '*' && Tablero[Coordenadas.X - VarX, Coordenadas.Y].Color == this.Color)
                    {
                        BlockU = true;
                    }
                    else if (Tablero[Coordenadas.X - VarX, Coordenadas.Y].Img != '*' && Tablero[Coordenadas.X - VarX, Coordenadas.Y].Color != this.Color)
                    {
                        Tablero[Coordenadas.X - VarX, Coordenadas.Y].Img = 'X';
                        BlockU = true;
                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (Tablero[Coordenadas.X, Coordenadas.Y + VarY].Img == '*' && BlockR == false)
                    {
                        Tablero[Coordenadas.X, Coordenadas.Y + VarY].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X, Coordenadas.Y + VarY].Img != '*' && Tablero[Coordenadas.X, Coordenadas.Y + VarY].Color == this.Color)
                    {
                        BlockR = true;
                    }
                    else if (Tablero[Coordenadas.X, Coordenadas.Y + VarY].Img != '*' && Tablero[Coordenadas.X, Coordenadas.Y + VarY].Color != this.Color)
                    {
                        Tablero[Coordenadas.X, Coordenadas.Y + VarY].Img = 'X';
                        BlockR = true;
                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (Tablero[Coordenadas.X, Coordenadas.Y - VarY].Img == '*' && BlockL == false)
                    {
                        Tablero[Coordenadas.X, Coordenadas.Y - VarY].Img = 'X';
                    }
                    else if (Tablero[Coordenadas.X, Coordenadas.Y - VarY].Img != '*' && Tablero[Coordenadas.X, Coordenadas.Y - VarY].Color == this.Color)
                    {
                        BlockL = true;
                    }
                    else if (Tablero[Coordenadas.X, Coordenadas.Y - VarY].Img != '*' && Tablero[Coordenadas.X, Coordenadas.Y - VarY].Color != this.Color)
                    {
                        Tablero[Coordenadas.X, Coordenadas.Y - VarY].Img = 'X';
                        BlockL = true;
                    }
                }
                catch (IndexOutOfRangeException) { }

                Tablero[Coordenadas.X, Coordenadas.Y].Img = 'T';
                VarX++;
                VarY++;
            }
        }

        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            MovAlfil(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);
            MovTorre(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);

            Tablero[Coordenadas.X, Coordenadas.Y].Img = 'r';
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
