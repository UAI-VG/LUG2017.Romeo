using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    class Program
    {
        public static Pieza[,] Tablero = new Pieza[8, 8]; //Instanciar un array que va a estar formado por piezas
        public static List<Coordenada> MovPosiblesBlancos = new List<Coordenada>(); // Listas para guardar los movimientos posibles de cada bando
        public static List<Coordenada> MovPosiblesNegros = new List<Coordenada>();
        public static List<Pieza> PiezasBlancasAmenazadas = new List<Pieza>();
        public static List<Pieza> PiezasNegrasAmenazadas = new List<Pieza>();


        static void CrearTablero()
        {
            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Tablero[f, c] = new PiezaVacia();
                }
            }
        } //Crear un array normal de piezas

        static void MostrarTablero()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            int var = 0;
            string letras = "ABCDEFGH";
            Console.WriteLine("  1 2 3 4 5 6 7 8");
            for (int f = 0; f < 8; f++)
            {
                Console.Write(letras[var].ToString() + " ");
                var++;
               
                for (int c = 0; c < 8; c++)
                {
                    if (Tablero[f, c] is PiezaVacia)
                    {
                        Tablero[f, c].Img = '*';
                    }
                    if (Tablero[f, c] is Torre)
                    {
                        Tablero[f, c].Img = 'T';
                    }
                    if (Tablero[f,c] is Rey)
                    {
                        Tablero[f, c].Img = 'R';
                    }
                    if (Tablero[f, c] is Peon)
                    {
                        Tablero[f, c].Img = 'P';
                    }
                    if (Tablero[f, c] is Alfil)
                    {
                        Tablero[f, c].Img = 'A';
                    }
                    if (Tablero[f, c] is Caballo)
                    {
                        Tablero[f, c].Img = 'C';
                    }
                    if (Tablero[f, c] is Reina)
                    {
                        Tablero[f, c].Img = 'r';
                    }
                    Console.Write(Tablero[f, c].Img + " ");                  
                }
                Console.WriteLine();
            }
        }//Muestra el array con retoques para que parezcan las letras al costado y en vez de empezar en 0 empieza en 1

        //Esto es para que se pueda escribir una letra y un numero para decir la posicion de la pieza y se encarga de pasarlo a solo numero para que la matriz entienda
        static Coordenada ObtenerCoordenadas()
        {
            Console.WriteLine("Coordenadas? Letra/Numero ");
            string input = Console.ReadLine();

            char Fila = input[0];
            char Columna = input[1];
                
            string Filas = "abcdefgh";
            int Fil = Filas.IndexOf(Fila);

            string Columnas = "12345678";
            int Col = Columnas.IndexOf(Columna);
            return new Coordenada(Fil, Col);
        }
          
        //Aca empieza el bardo
        static void PonerPieza()
        {
            Pieza Pieza = null; //Crea una pieza y la setea como null para despues asignarle la clase que el jugador elija
            Console.WriteLine();
            Console.WriteLine("Qué Pieza Quiere Poner? 'T'(Torre) / 'R' (Rey) / 'A' (Alfil) / 'h' (Reina) / 'C' (Caballo) / 'P' (Peon) ");
            char Opcion = char.Parse(Console.ReadLine());

            if (Opcion == 't' || Opcion =='T')
            {
                Pieza = new Torre();
            }
            else if (Opcion == 'r' || Opcion == 'R')
            {
                Pieza = new Rey();
            }
            else if (Opcion == 'a' || Opcion == 'A')
            {
                Pieza = new Alfil();
            }
            else if (Opcion == 'h' || Opcion == 'H')
            {
                Pieza = new Reina();
            }
            else if (Opcion == 'c' || Opcion == 'C')
            {
                Pieza = new Caballo();
            }
            else if (Opcion == 'p' || Opcion == 'P')
            {
                Pieza = new Peon();
            }
            //Segun la letra ingresada es una clase u otra
            
            //Lo mismo con el color
            Console.WriteLine("De que color? 'B' (Blanca) / 'N' (Negra)");
            char OpcionC = char.Parse(Console.ReadLine());

            if (OpcionC == 'b' || OpcionC == 'B')
            {
                Pieza.Color = 'B';
            }
            else if (OpcionC == 'n' || OpcionC == 'N')
            {
                Pieza.Color = 'N';
            }

            //La funcion ObtenerCoordenadas esta arriba comentada, la pieza creada obtiene su posicion de esta funcion
            Pieza.Posicion = ObtenerCoordenadas();

            //Estos son los 3 casos posibles (la posicion esta ocupada por una pieza de tu color, por una de otro color o por nadie)
            if (Tablero[Pieza.Posicion.X, Pieza.Posicion.Y] is PiezaVacia)
            {
                Tablero[Pieza.Posicion.X, Pieza.Posicion.Y].Img = Pieza.Img; //Se muestra en el tablero donde pusiste la pieza
                Pieza.CalcularMovimientos(Tablero, Pieza.Posicion, MovPosiblesBlancos, MovPosiblesNegros, Pieza.Color); //Se calculan los mov de esta
                Console.ReadKey();
            }
            else if (Tablero[Pieza.Posicion.X, Pieza.Posicion.Y].Color == Pieza.Color)
            {
                //No pasa nada
                Console.WriteLine("El Casillero esta ocupado por una pieza de tu color");
                Console.ReadKey();
            }
            else if (Tablero[Pieza.Posicion.X, Pieza.Posicion.Y].Color != Pieza.Color)
            {
                //Hace lo mismo que la primer condicion pero te tira un mensaje
                Console.WriteLine("Comiste una pieza de otro color");
                Console.ReadKey();             
                Pieza.CalcularMovimientos(Tablero, Pieza.Posicion, MovPosiblesBlancos, MovPosiblesNegros, Pieza.Color);
                Tablero[Pieza.Posicion.X, Pieza.Posicion.Y] = Pieza;
            }

        }

        static void ActualizarMovimientos(List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra, Pieza[,] Tablero)
        {     
            ListaBlanca.Clear(); //Limpia ambas listas de los movimientos viejos los cuales pudieron haber cambiado
            ListaNegra.Clear();
            
            foreach (Pieza p in Tablero)
            {
                //Recorre el tablero y a cada pieza le dice que calcule sus movimientos devuelta
                 p.CalcularMovimientos(Tablero, p.Posicion, MovPosiblesBlancos, MovPosiblesNegros, p.Color);         
            }
        }

        static void Puntuar(List<Coordenada>ListaBlanca, List<Coordenada> ListaNegra)
        {
            //Coordenada es una clase que cree yo que tiene 2 int (x,y) y un puntaje, dependiendo de a que pieza aloje dicha coordenada, su puntaje va a ser uno u otro
            foreach (Coordenada c in ListaBlanca)
            {
                if (Tablero[c.X, c.Y].Img == 'r' && Tablero[c.X, c.Y].Color != 'B')
                {
                    c.Puntaje = 9;
                }
                else if (Tablero[c.X, c.Y].Img == 'T' && Tablero[c.X, c.Y].Color != 'B')
                {
                    c.Puntaje = 5;
                }
                else if (Tablero[c.X, c.Y].Img == 'A' || Tablero[c.X, c.Y].Img == 'C' && Tablero[c.X, c.Y].Color != 'B')
                {
                    c.Puntaje = 3;
                }
                else if (Tablero[c.X, c.Y].Img == 'P' && Tablero[c.X, c.Y].Color != 'B')
                {
                    c.Puntaje = 1;
                }
                else
                {
                    c.Puntaje = 0;
                }
            }

            foreach (Coordenada c in ListaNegra) //Lo mismo pero en la otra lista
            {
                if (Tablero[c.X, c.Y].Img == 'r' && Tablero[c.X, c.Y].Color != 'N')
                {
                    c.Puntaje = 9;
                }
                else if (Tablero[c.X, c.Y].Img == 'T' && Tablero[c.X, c.Y].Color != 'N')
                {
                    c.Puntaje = 5;
                }
                else if (Tablero[c.X, c.Y].Img == 'A' || Tablero[c.X, c.Y].Img == 'C' && Tablero[c.X, c.Y].Color != 'N')
                {
                    c.Puntaje = 3;
                }
                else if (Tablero[c.X, c.Y].Img == 'P' && Tablero[c.X, c.Y].Color != 'N')
                {
                    c.Puntaje = 1;
                }
                else
                {
                    c.Puntaje = 0;
                }
            }
        }

        static void MostrarMovimientos(List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra)
        {
            Coordenada aux;
            for (int i = 1; i < ListaBlanca.Count - 1; i++)
            {
                for (int j = 0; j < ListaBlanca.Count - 1; j++)
                {
                    if (ListaBlanca[i].Puntaje > ListaBlanca[j].Puntaje)
                    {
                        aux = ListaBlanca[i];
                        ListaBlanca[i] = ListaBlanca[j];
                        ListaBlanca[j] = aux;
                    }
                }
            }

            Coordenada aux2;
            for (int i = 1; i < ListaNegra.Count - 1; i++)
            {
                for (int j = 0; j < ListaNegra.Count - 1; j++)
                {
                    if (ListaNegra[i].Puntaje > ListaNegra[j].Puntaje)
                    {
                        aux2 = ListaNegra[i];
                        ListaNegra[i] = ListaNegra[j];
                        ListaNegra[j] = aux2;
                    }
                }
            }

            //Esto muestra las listas de movimientos posibles, como los movimientos se devuelven
            //en dos int (x,y), lo que hace esto es que segun que fila este, pasa la fila de numero a letra
            //y a la columna le suma 1 para que no empiece desde 0 y todo tenga sentido visualmente
            Console.WriteLine("Movimientos Piezas Blancas");
            foreach (Coordenada c in ListaBlanca)
            {
                char letra = new char();
                c.Y += 1;
                if (c.X == 0) letra = 'a';
                else if (c.X == 1) letra = 'b';
                else if (c.X == 2) letra = 'c';
                else if (c.X == 3) letra = 'd';
                else if (c.X == 4) letra = 'e';
                else if (c.X == 5) letra = 'f';
                else if (c.X == 6) letra = 'g';
                else if (c.X == 7) letra = 'h';
                Console.WriteLine(letra + c.Y.ToString() + " Puntaje: " + c.Puntaje);
            }



            Console.WriteLine();
            Console.Write("****************************************");
            Console.WriteLine();
            Console.WriteLine("Movimientos Piezas Negras");
            //Lo mismo para la otra lista
            foreach (Coordenada c in ListaNegra)
            {
                char letra = new char();
                c.Y += 1;
                if (c.X == 0) letra = 'a';
                else if (c.X == 1) letra = 'b';
                else if (c.X == 2) letra = 'c';
                else if (c.X == 3) letra = 'd';
                else if (c.X == 4) letra = 'e';
                else if (c.X == 5) letra = 'f';
                else if (c.X == 6) letra = 'g';
                else if (c.X == 7) letra = 'h';
                Console.WriteLine(letra + c.Y.ToString() + " Puntaje: "+ c.Puntaje);
            }
        }

        static char TrasformarNumero(int n)
        {
            char letra = new char();
            if (n == 0) letra = 'a';
            else if (n == 1) letra = 'b';
            else if (n == 2) letra = 'c';
            else if (n == 3) letra = 'd';
            else if (n == 4) letra = 'e';
            else if (n == 5) letra = 'f';
            else if (n == 6) letra = 'g';
            else if (n == 7) letra = 'h';

            return letra;
        }

        static void EscribirArchivos()
        {
            Console.WriteLine("Guardando piezas blancas amenazadas");

            foreach (Pieza p in Tablero)
            {
                foreach (Coordenada c in MovPosiblesNegros)
                {
                    if (p.Color == 'B' && p.Posicion.X == c.X && p.Posicion.Y == c.Y)
                    {
                        PiezasBlancasAmenazadas.Add(p);
                    }
                }
            }
            Console.WriteLine("Piezas Blancas Guardadas");

            Console.WriteLine("Guardando piezas Negras amenazadas");
            foreach (Pieza p in Tablero)
            {
                foreach (Coordenada c in MovPosiblesBlancos)
                {
                    if (p.Color == 'N' && p.Posicion.X == c.X && p.Posicion.Y == c.Y)
                    {
                        PiezasNegrasAmenazadas.Add(p);
                    }
                }
            }
            Console.WriteLine("Piezas Negras Guardadas");

            using (StreamWriter writer = new StreamWriter(@"D:\out.txt", false, Encoding.UTF8))
            {
                foreach (Pieza p in PiezasBlancasAmenazadas)
                {
                    int num = new int();
                    if (p.Img != '*')
                        num = p.Posicion.Y + 1;
                    writer.Write(p.Img.ToString() + TrasformarNumero(p.Posicion.X) + num + ",");
                }
            }

            using (StreamWriter writer = new StreamWriter(@"D:\out.txt", true, Encoding.UTF8))
            {
                writer.WriteLine();

                foreach (Pieza p in PiezasNegrasAmenazadas)
                {
                    int num = new int();
                    if (p.Img != '*')
                        num = p.Posicion.Y + 1;
                    writer.Write(p.Img.ToString() + TrasformarNumero(p.Posicion.X) + num + ",");
                }
            }

            using (StreamWriter writer = new StreamWriter(@"D:\in.txt", false, Encoding.UTF8))
            {
                foreach (Pieza p in Tablero)
                {
                    int num = new int();
                    if (p.Img != '*')
                    num = p.Posicion.Y + 1;
                    if (p.Color == 'B')
                    {
                        writer.Write(p.Img.ToString() + TrasformarNumero(p.Posicion.X) + num + ",");
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(@"D:\in.txt", true, Encoding.UTF8))
            {
                writer.WriteLine();
                foreach (Pieza p in Tablero)
                {
                    int num = new int();
                    if (p.Img != '*')
                        num = p.Posicion.Y + 1;
                    if (p.Color == 'N')
                    {
                        writer.Write(p.Img.ToString() + TrasformarNumero(p.Posicion.X) +num + ",");
                    }
                }
            }



        }

        static void Main(string[] args)
        {
            char Terminar;
            CrearTablero();

            do
            {
                ActualizarMovimientos(MovPosiblesBlancos, MovPosiblesNegros, Tablero); //Al principio de actualizan todos los movimientos
                Puntuar(MovPosiblesBlancos, MovPosiblesNegros);//A todas las posiciones se les setea su puntaje
                MostrarTablero();//Se muestra el array con las piezas actuales
                PonerPieza();//Se pide poner una pieza nueva
                MostrarTablero();//Muestra el tablero con la ultima pieza agregada incluida
                Puntuar(MovPosiblesBlancos, MovPosiblesNegros);
                MostrarMovimientos(MovPosiblesBlancos, MovPosiblesNegros);//Muestra ambas listas de movimientos posibles

                Console.WriteLine();
                Console.WriteLine("Terminar (s)Si / (n)No "); //Loopea segun la respuesta
                Terminar = char.Parse(Console.ReadLine());
            } while (Terminar != 's');
            ActualizarMovimientos(MovPosiblesBlancos, MovPosiblesNegros, Tablero);
            MostrarTablero();
            EscribirArchivos();
           
            Console.ReadKey();
        }
    }
}
