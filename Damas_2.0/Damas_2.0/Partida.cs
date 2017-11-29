using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    class Partida
    {
        public bool Turno { get; set; }
        public Jugador Jugador1 { get; set; } = new Jugador();
        public Jugador Jugador2 { get; set; } = new Jugador();
        public Tablero Tablero { get; set; } = new Tablero(10, 10);
        Graficador Graficador = new Graficador();
        private bool Test = true;

        public void CrearPartida()
        {
            Turno = true;
            Tablero.Grilla = new Pieza[Tablero.Alto, Tablero.Ancho];

            if (!Test)
            {
                for (int f = 0; f < Tablero.Alto; f++)
                {
                    for (int c = 0; c < Tablero.Ancho; c += 2)
                    {
                        Tablero.Grilla[f, c] = new CasilleroVacio(null);
                        Tablero.Grilla[f, c].Icono = '·';
                        if (f == 1 || f == 3)
                        {
                            Tablero.Grilla[f, c] = new Ficha(Jugador1);
                            Tablero.Grilla[f, c].PosicionInicial = new Coordenada(f, c);
                            Jugador1.Piezas.Add(Tablero.Grilla[f, c]);
                            Tablero.Grilla[f, c].Icono = Tablero.Grilla[f, c].Icono;
                        }

                        if (f == 7 || f == 9)
                        {
                            Tablero.Grilla[f, c] = new Ficha(Jugador1);
                            Tablero.Grilla[f, c].PosicionInicial = new Coordenada(f, c);
                            Jugador2.Piezas.Add(Tablero.Grilla[f, c]);
                            Tablero.Grilla[f, c].Icono = Tablero.Grilla[f, c].Icono;
                        }
                    }
                }

                for (int f = 0; f < Tablero.Alto; f++)
                {
                    for (int c = 1; c < Tablero.Ancho; c += 2)
                    {
                        Tablero.Grilla[f, c] = new CasilleroVacio(null);
                        Tablero.Grilla[f, c].Icono = '·';

                        if (f == 0 || f == 2)
                        {
                            Tablero.Grilla[f, c] = new Ficha(Jugador1);
                            Tablero.Grilla[f, c].PosicionInicial = new Coordenada(f, c);
                            Jugador1.Piezas.Add(Tablero.Grilla[f, c]);
                            Tablero.Grilla[f, c].Icono = Tablero.Grilla[f, c].Icono;
                        }

                        if (f == 6 || f == 8)
                        {
                            Tablero.Grilla[f, c] = new Ficha(Jugador2);
                            Tablero.Grilla[f, c].PosicionInicial = new Coordenada(f, c);
                            Jugador2.Piezas.Add(Tablero.Grilla[f, c]);
                            Tablero.Grilla[f, c].Icono = Tablero.Grilla[f, c].Icono;
                        }
                    }
                }

            }
            else //MODO TEST
            {
                for (int f = 0; f < Tablero.Alto; f++)
                {
                    for (int c = 0; c < Tablero.Alto; c++)
                    {
                        Tablero.Grilla[f, c] = new CasilleroVacio(null);
                        Tablero.Grilla[f, c].Icono = '·';
                    }
                }

                Tablero.Grilla[7, 2] = new Dama(Jugador2);
                Tablero.Grilla[7, 2].PosicionInicial = new Coordenada(7, 2);
                Jugador2.Piezas.Add(Tablero.Grilla[7, 2]);

                Tablero.Grilla[2, 7] = new Ficha(Jugador1);
                Tablero.Grilla[2, 3] = new Ficha(Jugador1);
                Tablero.Grilla[4, 5] = new Ficha(Jugador1);
                Tablero.Grilla[3, 2] = new Ficha(Jugador1);

                Tablero.Grilla[2, 7].PosicionInicial = new Coordenada(2, 7);
                Tablero.Grilla[2, 3].PosicionInicial = new Coordenada(2, 3);
                Tablero.Grilla[4, 5].PosicionInicial = new Coordenada(4, 5);
                Tablero.Grilla[3, 2].PosicionInicial = new Coordenada(3, 2);

                Jugador1.Piezas.Add(Tablero.Grilla[3, 2]);
                Jugador1.Piezas.Add(Tablero.Grilla[2, 3]);
                Jugador1.Piezas.Add(Tablero.Grilla[2, 7]);
                Jugador1.Piezas.Add(Tablero.Grilla[4, 5]);

            }
            foreach (Pieza p in Jugador1.Piezas)
            {
                p.Icono = 'X';
            }

            foreach (Pieza p in Jugador2.Piezas)
            {
                p.Icono = 'O';
            }

            Jugador1.Tablero = Tablero;
            Jugador2.Tablero = Tablero;
            Graficador.GraficarTablero(Tablero);
            Console.WriteLine();
        }

        public void Jugar()
        {
            Console.Clear();
            Graficador.GraficarTablero(Tablero);
            Console.WriteLine();
            Jugador JugadorActual;
            if (Turno)
            {
                JugadorActual = Jugador1;
                Console.WriteLine("Turno de Jugador 1 'O'");
            }
            else if (!Turno)
            {
                JugadorActual = Jugador2;
                Console.WriteLine("Turno de Jugador 2 'X'");
            }
            
            Console.WriteLine("Elija una ficha para mostrar sus movimientos");
            try
            {
                Console.Write("Fila: "); int Fila = int.Parse(Console.ReadLine());
                Console.Write("Columna: "); int Columna = int.Parse(Console.ReadLine());

                if (Tablero.Grilla[Fila, Columna].Icono == 'O' && Turno || Tablero.Grilla[Fila, Columna].Icono == 'X' && !Turno)
                {
                    List<Coordenada> Ejemplo = new List<Coordenada>();
                    Ejemplo = Tablero.Grilla[Fila, Columna].CalcularMovimientos(Tablero.Grilla[Fila,Columna].PosicionInicial, Tablero);
                    Console.WriteLine("Posibles Movimientos:");
                    Console.WriteLine();

                    if (Ejemplo.Count == 0)
                    {
                        Console.WriteLine("Esta ficha no tiene movimientos posibles");
                    }
                    else
                    {
                        foreach (Coordenada c in Ejemplo)
                        {
                            if (c != null)
                            Console.WriteLine("Fila: " + c.X + " " + "Columna: " + c.Y + " " + "(" + Ejemplo.IndexOf(c) + ")");
                        }

                        Console.WriteLine();
                        Console.WriteLine("A que posicion Mover? ");

                        int Jugada = int.Parse(Console.ReadLine());
                        Coordenada Destino = Ejemplo[Jugada];

                        Tablero.MoverPieza(Tablero.Grilla[Fila,Columna], Destino);

                        foreach (Coordenada c in Ejemplo)
                        {
                            c.PiezasComidas.Clear();
                        }

                        Ejemplo.Clear();

                        Turno = !Turno;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ficha Equivocada");
                    Console.ReadKey();
                    Console.Clear();
                    Graficador.GraficarTablero(Tablero);
                    Console.WriteLine();
                    Jugar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                Jugar();
            }
        }
    }
}
