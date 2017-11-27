using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    public class Tablero : ICloneable
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public Pieza[,] Grilla { get; set; }
        public List<Pieza> PiezasComidas { get; set; } = new List<Pieza>();

        public Tablero(int Alto, int Ancho)
        {
            this.Alto = Alto;
            this.Ancho = Ancho;
        }

        public void MoverPieza(Pieza Pieza, Coordenada Destino)
        {
            Grilla[Destino.X, Destino.Y] = new Ficha(Pieza.Jugador);
            Grilla[Destino.X, Destino.Y].PosicionInicial = Destino;
            Grilla[Destino.X, Destino.Y].Icono = Pieza.Icono;
            Grilla[Pieza.PosicionInicial.X, Pieza.PosicionInicial.Y] = new CasilleroVacio(null);
            Grilla[Pieza.PosicionInicial.X, Pieza.PosicionInicial.Y].Icono = '·';

            foreach (Pieza p in Destino.PiezasComidas)
            {
                p.Jugador.Piezas.Remove(p);
                Grilla[p.PosicionInicial.X, p.PosicionInicial.Y] = new CasilleroVacio(null);
                Grilla[p.PosicionInicial.X, p.PosicionInicial.Y].Icono = '·';
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
