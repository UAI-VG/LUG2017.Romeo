using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Rey : Pieza
    {

        void UbicarRey(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            //Cada try/catch corresponde a un enroque, basicamente, si tiene una torre al rango, se modifican sus posiciones

            //Enroque largo************************************
            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y - 3] is Torre && Tablero[Coordenadas.X, Coordenadas.Y - 3].Color == Color)
                {
                    Console.WriteLine("Desea Realizar un enroque? (s)Si / (n)No");
                    char Opcion = char.Parse(Console.ReadLine());

                    if (Opcion == 's')
                    {
                        Pieza torre = new Torre();
                        Pieza vacio = new PiezaVacia();
                        vacio.Img = '*';
                        Tablero[Coordenadas.X, Coordenadas.Y].Img = '*';
                        torre = Tablero[Coordenadas.X, Coordenadas.Y - 3];
                        Tablero[Coordenadas.X, Coordenadas.Y - 3] = vacio;
                        Tablero[Coordenadas.X, Coordenadas.Y - 1] = torre;
                        Tablero[Coordenadas.X, Coordenadas.Y - 1].Img = 'T';
                        Coordenadas.Y -= 2;
                    }
                    else { }
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y + 3] is Torre && Tablero[Coordenadas.X, Coordenadas.Y + 3].Color == Color)
                {
                    Console.WriteLine("Desea Realizar un enroque? (s)Si / (n)No");
                    char Opcionb = char.Parse(Console.ReadLine());

                    if (Opcionb == 's')
                    {
                        Pieza torre = new Torre();
                        Pieza vacio = new PiezaVacia();
                        vacio.Img = '*';
                        Tablero[Coordenadas.X, Coordenadas.Y].Img = '*';
                        torre = Tablero[Coordenadas.X, Coordenadas.Y + 3];
                        Tablero[Coordenadas.X, Coordenadas.Y + 3] = vacio;
                        Tablero[Coordenadas.X, Coordenadas.Y + 1] = torre;
                        Tablero[Coordenadas.X, Coordenadas.Y + 1].Img = 'T';
                        Coordenadas.Y += 2;
                    }
                    else { }
                }
            }
            catch (IndexOutOfRangeException) { }

            //Enroque corto*******************************

            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y - 2] is Torre && Tablero[Coordenadas.X, Coordenadas.Y - 2].Color == Color)
                {
                    Console.WriteLine("Desea Realizar un enroque? (s)Si / (n)No");
                    char Opcion = char.Parse(Console.ReadLine());

                    if (Opcion == 's')
                    {
                        Pieza torre = new Torre();
                        Pieza vacio = new PiezaVacia();
                        vacio.Img = '*';
                        Tablero[Coordenadas.X, Coordenadas.Y].Img = '*';
                        torre = Tablero[Coordenadas.X, Coordenadas.Y - 2];
                        Tablero[Coordenadas.X, Coordenadas.Y - 2] = vacio;
                        Tablero[Coordenadas.X, Coordenadas.Y - 1] = torre;
                        Tablero[Coordenadas.X, Coordenadas.Y - 1].Img = 'T';
                        Coordenadas.Y -= 2;
                    }
                    else { }
                }
            }
            catch (IndexOutOfRangeException) { }

            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y + 2] is Torre && Tablero[Coordenadas.X, Coordenadas.Y + 2].Color == Color)
                {
                    Console.WriteLine("Desea Realizar un enroque? (s)Si / (n)No");
                    char Opcion = char.Parse(Console.ReadLine());

                    if (Opcion == 's')
                    {
                        Pieza torre = new Torre();
                        Pieza vacio = new PiezaVacia();
                        vacio.Img = '*';
                        Tablero[Coordenadas.X, Coordenadas.Y].Img = '*';
                        torre = Tablero[Coordenadas.X, Coordenadas.Y + 2];
                        Tablero[Coordenadas.X, Coordenadas.Y + 2] = vacio;
                        Tablero[Coordenadas.X, Coordenadas.Y + 1] = torre;
                        Tablero[Coordenadas.X, Coordenadas.Y + 1].Img = 'T';
                        Coordenadas.Y += 2;
                    }
                    else { }
                }
            }
            catch (IndexOutOfRangeException) { }



            // No enroque
            try
            {
                if (Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Img == '*' || Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Color != this.Color)
                Tablero[Coordenadas.X - 1, Coordenadas.Y - 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X - 1, Coordenadas.Y].Img == '*' || Tablero[Coordenadas.X - 1, Coordenadas.Y].Color != this.Color)
                    Tablero[Coordenadas.X - 1, Coordenadas.Y].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Img == '*' || Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Color != this.Color)
                    Tablero[Coordenadas.X - 1, Coordenadas.Y + 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y - 1].Img == '*' || Tablero[Coordenadas.X, Coordenadas.Y - 1].Color != this.Color)
                    Tablero[Coordenadas.X, Coordenadas.Y - 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X, Coordenadas.Y + 1].Img == '*' || Tablero[Coordenadas.X, Coordenadas.Y + 1].Color != this.Color)
                    Tablero[Coordenadas.X, Coordenadas.Y + 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Img == '*' || Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Color != this.Color)
                    Tablero[Coordenadas.X + 1, Coordenadas.Y - 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X + 1, Coordenadas.Y].Img == '*' || Tablero[Coordenadas.X + 1, Coordenadas.Y].Color != this.Color)
                    Tablero[Coordenadas.X + 1, Coordenadas.Y].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Img == '*' || Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Color != this.Color)
                    Tablero[Coordenadas.X + 1, Coordenadas.Y + 1].Img = 'X';
            }
            catch (IndexOutOfRangeException) { }

            Tablero[Coordenadas.X, Coordenadas.Y].Img = 'R';
            int var = 0;
            string letras = "ABCDEFGH";
            Console.Clear();
            Console.WriteLine("  1 2 3 4 5 6 7 8");
            for (int f = 0; f < 8; f++)
            {
                Console.Write(letras[var].ToString() + " ");
                var++;
                for (int c = 0; c < 8; c++)
                {
                    if (Tablero[f, c].Img == 'X')
                    {
                        Coordenada MovPos = new Coordenada(f,c);
                     /*   MovPos.X = f;
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
        }

        bool Jaque;

        //El CalcularMovimientos del Rey es diferente porque antes debe verificar que la posicion del rey no este en la lista de movimientos
        //del bando contraria asi no cae en jaque
        public override void CalcularMovimientos(Pieza[,] Tablero, Coordenada Coordenadas, List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, char Color)
        {
            //Dependiendo del color del rey recorre una lista u otra, y compara cada posicion de estas con su posicion
            //Si hay coincidencia no te deja poner al rey, caso contraria, todo normal
            if (Color == 'B')
            {
                if (ListaNegra.Count > 0)
                {
                    foreach (Coordenada x in ListaNegra)
                    {
                        if (x.X == Coordenadas.X && x.Y == Coordenadas.Y)
                        {
                            Console.WriteLine("No se puede poner al Rey en jaque");
                            Jaque = true;
                        }
                    }

                    if (Jaque == false)
                    {
                        UbicarRey(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);
                        Tablero[Coordenadas.X, Coordenadas.Y] = this;
                    }

                }
                else if (ListaNegra.Count == 0)
                {
                    UbicarRey(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);
                    Tablero[Coordenadas.X, Coordenadas.Y] = this;
                }
            }
            else if (Color == 'N')
            {
                if (ListaBlanca.Count > 0)
                {
                    foreach (Coordenada c in ListaBlanca)
                    {
                        if (c.X == Coordenadas.X && c.Y == Coordenadas.Y)
                        {
                            Console.WriteLine("No se puede poner al Rey en jaque");
                            Jaque = true;
                        }
                    }

                    if (Jaque == false)
                    {
                        UbicarRey(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);
                        Tablero[Coordenadas.X, Coordenadas.Y] = this;
                    }
                }
                else if (ListaBlanca.Count == 0)
                {
                    UbicarRey(Tablero, Coordenadas, ListaBlanca, ListaNegra, Color);
                    Tablero[Coordenadas.X, Coordenadas.Y] = this;
                }
            }
        }
    }
}
