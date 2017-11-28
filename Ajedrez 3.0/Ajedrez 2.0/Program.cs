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
        public static bool Turno = new bool();
        public static List<string> Text = new List<string>();
        static void CrearTablero()
        {
            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Tablero[f, c] = new PiezaVacia();
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Tablero[1, i] = new Peon();
                Tablero[1, i].Color = 'N';

                Tablero[6, i] = new Peon();
                Tablero[6, i].Color = 'B';
            } //Peones

            Tablero[0, 0] = new Torre();
            Tablero[0, 0].Color = 'N';
            Tablero[0, 7] = Tablero[0, 0];

            Tablero[7, 0] = new Torre();
            Tablero[7, 0].Color = 'B';
            Tablero[7, 7] = Tablero[7, 0];

            Tablero[0, 6] = new Caballo();
            Tablero[0, 6].Color = 'N';
            Tablero[0, 1] = Tablero[0, 6];

            Tablero[7, 6] = new Caballo();
            Tablero[7, 6].Color = 'B';
            Tablero[7, 1] = Tablero[7, 6];

            Tablero[0, 5] = new Alfil();
            Tablero[0, 5].Color = 'N';
            Tablero[0, 2] = Tablero[0, 5];

            Tablero[7, 5] = new Alfil();
            Tablero[7, 5].Color = 'B';
            Tablero[7, 2] = Tablero[7, 5];

            Tablero[0, 4] = new Reina();
            Tablero[0, 4].Color = 'N';
            Tablero[0, 3] = new Rey();
            Tablero[0, 3].Color = 'N';

            Tablero[7, 3] = new Reina();
            Tablero[7, 3].Color = 'B';
            Tablero[7, 4] = new Rey();
            Tablero[7, 4].Color = 'B';

            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Tablero[f, c].Posicion = new Coordenada(f, c);
                }
            }
        } //Crear un array normal de piezas

        static void CrearTableroLeyendo()
        {
            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Tablero[f, c] = new PiezaVacia();
                }
            }

            foreach (string s in Text)
            {
                Pieza p = null;
                int x = new int();
                int y = new int();

                if (s[0] == 'R')
                {
                    p = new Rey();
                }
                else if (s[0] == 'A')
                {
                    p = new Alfil();
                }
                else if (s[0] == 'C')
                {
                    p = new Caballo();
                }
                else if (s[0] == 'r')
                {
                    p = new Reina();
                }
                else if (s[0] == 'P')
                {
                    p = new Peon();
                }
                else if (s[0] == 'T')
                {
                    p = new Torre();
                }
                else if (s[0] == '*')
                {
                    p = new PiezaVacia();
                }

                char n = s[1];

                if (n == 'a') x = 0;
                else if (n == 'b') x = 1;
                else if (n == 'c') x = 2;
                else if (n == 'd') x = 3;
                else if (n == 'e') x = 4;
                else if (n == 'f') x = 5;
                else if (n == 'g') x = 6;
                else if (n == 'h') x = 7;

                if (s[2] == '1') y = 0;
                else if (s[2] == '2') y = 1;
                else if (s[2] == '3') y = 2;
                else if (s[2] == '4') y = 3;
                else if (s[2] == '5') y = 4;
                else if (s[2] == '6') y = 5;
                else if (s[2] == '7') y = 6;
                else if (s[2] == '8') y = 7;

                p.Color = s[3];
                p.Posicion = new Coordenada(x, y);
                Tablero[x, y] = p;

            }

        }

        static void UbicarPierzas()
        {
            MovPosiblesNegros.Clear();
            MovPosiblesBlancos.Clear();
            MostrarTablero();
            Console.WriteLine("Pieza a mover");
            Coordenada PosInicial = ObtenerCoordenadas();
            if (Turno && Tablero[PosInicial.X, PosInicial.Y].Color == 'N' || !Turno && Tablero[PosInicial.X, PosInicial.Y].Color == 'B')
            {
                Console.WriteLine("No se pueden mover piezas enemigas");
                Console.ReadKey();
                UbicarPierzas();
            }
            else if ((Turno && Tablero[PosInicial.X, PosInicial.Y].Color == 'B' || (!Turno && Tablero[PosInicial.X, PosInicial.Y].Color == 'N')))
            {
                MostrarTablero();
                Console.WriteLine("A donde mover");
                Coordenada PosFinal = ObtenerCoordenadas();

                ComandoMover command = new ComandoMover(Tablero[PosInicial.X, PosInicial.Y], PosInicial, PosFinal, Tablero, MovPosiblesBlancos, MovPosiblesNegros);
                EditorCommandManager.Instance.Do(command);
            }
        }

        static void MostrarTablero()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            if (Turno)
            {
                Console.WriteLine("Turno de Blancas");
            }
            else
            {
                Console.WriteLine("Turno de Negras");
            }
            Console.WriteLine();
            int var = 0;
            string letras = "abcdefgh";
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
                if (Tablero[c.X, c.Y] is Reina)
                {
                    c.Puntaje += 9;
                }
                else if (Tablero[c.X, c.Y] is Torre)
                {
                    c.Puntaje += 5;
                }
                else if (Tablero[c.X, c.Y] is Alfil || Tablero[c.X, c.Y] is Caballo)
                {
                    c.Puntaje += 3;
                }
                else if (Tablero[c.X, c.Y] is Peon)
                {
                    c.Puntaje += 1;
                }
                else
                {
                    c.Puntaje += 0;
                }
            }

            foreach (Coordenada c in ListaNegra) //Lo mismo pero en la otra lista
            {
                if (Tablero[c.X, c.Y] is Reina)
                {
                    c.Puntaje += 9;
                }
                else if (Tablero[c.X, c.Y] is Torre)
                {
                    c.Puntaje += 5;
                }
                else if (Tablero[c.X, c.Y] is Alfil || Tablero[c.X, c.Y] is Caballo)
                {
                    c.Puntaje += 3;
                }
                else if (Tablero[c.X, c.Y] is Peon)
                {
                    c.Puntaje += 1;
                }
                else
                {
                    c.Puntaje += 0;
                }
            }
        }

        static void MostrarMovimientos(List<Coordenada> ListaBlanca, List<Coordenada> ListaNegra)
        {
            Coordenada aux;
            for (int i = 0; i < ListaBlanca.Count - 1; i++)
            {
                for (int j = i + 1; j < ListaBlanca.Count; j++)
                {
                    if (ListaBlanca[i].Puntaje > ListaBlanca[j].Puntaje)
                    {
                        aux = ListaBlanca[j];
                        ListaBlanca[j] = ListaBlanca[i];
                        ListaBlanca[i] = aux;
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
                Console.WriteLine(letra + c.Y.ToString());
            }



            Console.WriteLine();
            Console.Write("****************************************");
            Console.WriteLine();

            //Coordenada aux2;
            //for (int x = 0; x < ListaNegra.Count - 1; x++)
            //{
            //    for (int y = x + 1; y < ListaNegra.Count; y++)
            //    {
            //        if (ListaBlanca[x].Puntaje > ListaNegra[y].Puntaje)
            //        {
            //            aux2 = ListaBlanca[y];
            //            ListaNegra[y] = ListaNegra[x];
            //            ListaNegra[x] = aux2;
            //        }
            //    }
            //}

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
                Console.WriteLine(letra + c.Y.ToString());
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
            using (StreamWriter writer = new StreamWriter(@"D:\Tablero.txt", false, Encoding.UTF8))
            {
                for (int f = 0; f < 8; f++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        Tablero[f, c].Posicion = new Coordenada(f, c);
                        Tablero[f, c].Posicion.Y += 1;
                        writer.WriteLine(Tablero[f, c].Img.ToString() + TrasformarNumero(Tablero[f, c].Posicion.X) + Tablero[f, c].Posicion.Y + Tablero[f,c].Color.ToString());
                        Tablero[f, c].Posicion.Y -= 1;
                    }
                }
            }
        }

        static void LeerArchivo()
        {
            StreamReader Reader = new StreamReader(@"D:\\Tablero.txt");
            string sLine = "";

            while (sLine != null)
            {
                sLine = Reader.ReadLine();
                if (sLine != null)
                    Text.Add(sLine);
            }
            Reader.Close();
        }

        static void Main(string[] args)
        {
            char Terminar;
            char Terminar2;
            Turno = true;

            if (!File.Exists(@"D:\Tablero.txt"))
            {
                StreamWriter writer = new System.IO.StreamWriter(@"D:\Tablero.txt");
                writer.Close();
            }

            LeerArchivo();
            
            if (Text.Count == 0)
            {
                CrearTablero();
            }
            else if (Text.Count > 0)
            {
                CrearTableroLeyendo();
            }
            MostrarTablero();
            do
            {
                UbicarPierzas();
                MostrarTablero();
                Puntuar(MovPosiblesBlancos, MovPosiblesNegros);
                Console.WriteLine();
                Console.WriteLine("Terminar? (s) Pasar al menu Undo/Redo / (n)Pasar Turno"); //Loopea segun la respuesta
                Turno = !Turno;
                Terminar = char.Parse(Console.ReadLine());
            } while (Terminar != 's');

            do
            {
                Console.WriteLine();
                Console.WriteLine("Deshacer movimiento? (z)Undo / (r)Redo / (s)Guardar Y Salir");

                Terminar2 = char.Parse(Console.ReadLine());

                if (Terminar2 == 'z')
                {
                    EditorCommandManager.Instance.Undo();
                    MostrarTablero();
                }
                else if (Terminar2 == 'r')
                {
                    EditorCommandManager.Instance.Redo();
                    MostrarTablero();
                }
            } while (Terminar2 != 's');

            EscribirArchivos();
            Console.WriteLine("Tablero Guardado");
            //do
            //{
            //    ActualizarMovimientos(MovPosiblesBlancos, MovPosiblesNegros, Tablero); //Al principio de actualizan todos los movimientos
            //    Puntuar(MovPosiblesBlancos, MovPosiblesNegros);//A todas las posiciones se les setea su puntaje
            //    MostrarTablero();//Se muestra el array con las piezas actuales
            //    PonerPieza();//Se pide poner una pieza nueva
            //    MostrarTablero();//Muestra el tablero con la ultima pieza agregada incluida
            //    MostrarMovimientos(MovPosiblesBlancos, MovPosiblesNegros);//Muestra ambas listas de movimientos posibles

            //    Console.WriteLine();
            //    Console.WriteLine("Terminar (s)Si / (n)No "); //Loopea segun la respuesta
            //    Terminar = char.Parse(Console.ReadLine());
            //} while (Terminar != 's');
            //ActualizarMovimientos(MovPosiblesBlancos, MovPosiblesNegros, Tablero);
            //MostrarTablero();
            //EscribirArchivos();

            Console.ReadKey();
        }
    }
}
