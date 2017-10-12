﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    public class Tablero
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public Pieza[,] Grilla { get; set; }

        public Tablero(int Alto, int Ancho)
        {
            this.Alto = Alto;
            this.Ancho = Ancho;
        }

        void MoverPieza(Pieza Pieza, Coordenada Destino)
        {
            Pieza.PosicionInicial = Destino;
        }
    }
}
