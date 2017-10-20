using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Caballo : Pieza
    {
        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            try
            {
                if (Tablero[Coordenadas.X - 1, Coordenadas.Y + 2].Color != this.Color || Tablero[Coordenadas.X - 1, Coordenadas.Y + 2].Img == '*')
                {
                    Tablero[Coordenadas.X - 1, Coordenadas.Y + 2].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X - 2, Coordenadas.Y + 1].Color != this.Color || Tablero[Coordenadas.X - 2, Coordenadas.Y + 1].Img == '*')
                {
                    Tablero[Coordenadas.X - 2, Coordenadas.Y + 1].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X - 1, Coordenadas.Y - 2].Color != this.Color || Tablero[Coordenadas.X - 1, Coordenadas.Y - 2].Img == '*')
                {
                    Tablero[Coordenadas.X - 1, Coordenadas.Y - 2].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X - 2, Coordenadas.Y - 1].Color != this.Color || Tablero[Coordenadas.X - 2, Coordenadas.Y - 1].Img == '*')
                {
                    Tablero[Coordenadas.X - 2, Coordenadas.Y - 1].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X + 1, Coordenadas.Y + 2].Color != this.Color || Tablero[Coordenadas.X + 1, Coordenadas.Y + 2].Img == '*')
                {
                    Tablero[Coordenadas.X + 1, Coordenadas.Y + 2].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X + 2, Coordenadas.Y + 1].Color != this.Color || Tablero[Coordenadas.X + 2, Coordenadas.Y + 1].Img == '*')
                {
                    Tablero[Coordenadas.X + 2, Coordenadas.Y + 1].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X + 1, Coordenadas.Y - 2].Color != this.Color || Tablero[Coordenadas.X + 1, Coordenadas.Y - 2].Img == '*')
                {
                    Tablero[Coordenadas.X + 1, Coordenadas.Y - 2].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X + 2, Coordenadas.Y - 1].Color != this.Color || Tablero[Coordenadas.X + 2, Coordenadas.Y - 1].Img == '*')
                {
                    Tablero[Coordenadas.X + 2, Coordenadas.Y - 1].Img = 'X';
                }
            }
            catch (IndexOutOfRangeException) { }

            Tablero[Coordenadas.X, Coordenadas.Y].Img = 'C';
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
                       /* MovPos.X = f;
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
