using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    public class Coordenada
    {
         public int X { get; set; } //Propiedades de la coordenada
         public int Y { get; set; }
         public int Puntaje { get; set; }

        public Coordenada (int Fil, int Col) //Un constructor para despues poder hacer que esta clase retorne variables (se usa en ObtenerCoordenadas())
        {
            X = Fil;
            Y = Col;
        }
    }
}
