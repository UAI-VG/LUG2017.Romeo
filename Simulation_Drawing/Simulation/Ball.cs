using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    public class Ball
    {
        public PointF Position { get; set; }
        public PointF Speed { get; set; }
        public double Radius { get; set; }

        public void StepOn(Scene scene)
        {
            Position = new PointF(Position.X + Speed.X, Position.Y + Speed.Y);

            if (Position.X - Radius < 0
                || Position.X + Radius > scene.Size.Width)
            {
                Speed = new PointF(Speed.X * -1, Speed.Y);
            }

            if (Position.Y - Radius < 0
                || Position.Y + Radius > scene.Size.Height)
            {
                Speed = new PointF(Speed.X, Speed.Y * -1);
            }
        }

        public override string ToString()
        {
            return string.Format("Ball(x: {0}, y: {1})", Position.X, Position.Y);
        }

        public Ball Clone()
        {
            return new Ball()
            {
                Position = Position,
                Speed = Speed,
                Radius = Radius
            };
        }
    }
}
