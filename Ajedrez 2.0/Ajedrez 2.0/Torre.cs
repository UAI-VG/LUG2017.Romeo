using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    public class Torre : Pieza
    {

        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
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
                catch(IndexOutOfRangeException) { }

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
                catch(IndexOutOfRangeException) { }

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
                catch(IndexOutOfRangeException) { }

                Tablero[Coordenadas.X, Coordenadas.Y].Img = 'T';
                VarX++;
                VarY++;
            }

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
                  if(Tablero[f,c].Img == 'X')
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
