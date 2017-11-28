using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Damas_2._0
{
    [Serializable]
    public class Clonador
    {
        public Tablero Clonar (Tablero Tablero)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Tablero);
                stream.Position = 0;
                return (Tablero)formatter.Deserialize(stream);               
            }
        }
    }
}
