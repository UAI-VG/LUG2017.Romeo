using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    class Program
    {
        public static Partida Juego = new Partida();

        static void Main(string[] args)
        {

            Juego.CrearPartida();

            while (true)
            {
                Juego.Jugar();
            }
        }
    }
}
