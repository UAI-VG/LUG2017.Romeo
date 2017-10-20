using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Alfil : Pieza
    {
        //Esto recibe al tablero, ambas listas, y el color de la pieza que se esta poniendo, tambien la posicion donde se va a poner a la misma
        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            //Estas varibles son para que el alfil pueda marcar sus diagonales progresivamente
            int VarX1 = 1;
            int VarX2 = 1;
            int VarX3 = 1;
            int VarX4 = 1;
            int VarY1 = 1;
            int VarY2 = 1;
            int VarY3 = 1;
            int VarY4 = 1;

            //Estas 4 variables, cuando se vuelven true, evitan que el alfin siga marcando posibles posiciones en una diagonal
            bool BlockUL = false; //Arriba Izquierda
            bool BlockDL = false; //Abajo Izquierda
            bool BlockUR = false; //Arriba Derecha
            bool BlockDR = false; //Abajo Derecha


            for (int i = 0; i < 7; i++)
            { //Uso try y catch para marca, asi en caso de que el alfil intente marcar fuera del array no salte un error
                //sino que deja de marcar (como si fuera un limitador), cada try/catch corresponde a una diagonal
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
            //Por ultimo muestra el tablero con los posibles movimientos marcados con X
            //Al salir de esta funcion, en el main, el tablero borra las X y solo muestra la pieza
            Tablero[Coordenadas.X, Coordenadas.Y].Img = 'A';
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
                    //Como el alfil marco sus posibles movimientos con X, esto recorre el tablero y si es una X lo agrega 
                    //A la lista de posibles movimientos, obviamente dependiendo del color del alfil va a una lista u otra
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
            Tablero[Coordenadas.X, Coordenadas.Y] = this; //Esto es para que en el tablero, cambie la pieza por esta
        }
    }
}
