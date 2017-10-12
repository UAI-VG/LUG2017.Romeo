using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    class Graficador
    {
        public void GraficarTablero(Tablero Tablero)
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            Console.Write("______________________");
            Console.WriteLine();
            for (int f = 0; f < Tablero.Alto; f++)
            {
                Console.Write(f + "| ");
                for (int c = 0; c < Tablero.Ancho; c++)
                {
                    if (Tablero.Grilla[f, c] != null)
                    Console.Write(Tablero.Grilla[f,c].Icono + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
