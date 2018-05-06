using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    public class Scene
    {
        private SizeF size;
        private List<Ball> entities;

        public Scene(SizeF size, List<Ball> entities)
        {
            this.size = size;
            this.entities = entities;
        }

        public Scene(SizeF size)
        {
            this.size = size;
            entities = new List<Ball>();
            double angle = Math.PI / 180 * 45;
            for (int i = 1; i < 49; i++)
            {
                Entities.Add(new Ball()
                {
                    Position = new PointF(i * 2, i * 2),
                    Speed = new PointF((float)Math.Cos(angle), (float)Math.Sin(angle)),
                    Radius = 1
                });
                angle += Math.PI / 180 * 5;
            }
        }

        public SizeF Size { get { return size; } }
        public List<Ball> Entities { get { return entities; } }

        public Scene Clone()
        {
            List<Ball> entitiesCopy = new List<Ball>();
            foreach (var b in Entities)
            {
                entitiesCopy.Add(b.Clone());
            }
            return new Scene(Size, entitiesCopy);
        }

        public void Step()
        {
            Entities.ForEach((b) => b.StepOn(this));
        }

        public override string ToString()
        {
            return entities[0].ToString();
        }
    }
}
