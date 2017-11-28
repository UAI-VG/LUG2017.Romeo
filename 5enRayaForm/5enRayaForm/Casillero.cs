using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CincoEnRaya.Model;

namespace _5enRayaForm
{
    class Casillero
    {
        public void Dibujar(Graphics graficador,Board Board, int OX, int OY, int Ancho, int Alto)
        {
            for (int Y=0; Y < Board.Width; Y++)
            {
                for (int X = 0; X < Board.Height; X++)
                {
                    graficador.FillEllipse(Brushes.Black, Y * Alto + OY, X * Ancho + OX, Ancho, Alto);

                    if (Board.Get(Y, X) != null && Board.Get(Y,X).player.Name == "Human")
                    {
                        graficador.FillEllipse(Brushes.Red, Y * Alto + OY, X * Ancho + OX, Ancho, Alto);
                    }     
                    else if (Board.Get(Y, X) != null && Board.Get(Y, X).player.Name == "CPU")
                    {
                        graficador.FillEllipse(Brushes.Blue, Y * Alto + OY, X * Ancho + OX, Ancho, Alto);
                    }        
                }
            }         
        }
    }
}
