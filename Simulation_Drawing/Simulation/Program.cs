using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Simulation
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //PrintFrame(1500000);
            //PrintFrame(100000);
            //PrintFrame(10);
            //PrintFrame(1500);
            //PrintFrame(3);
            //PrintFrame(200000);
            //PrintFrame(2000001);
            //PrintFrame(5);
            //PrintFrame(105);

            //Console.Read();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimulationViewer());
        }

        static void PrintFrame(int frame)
        {
            Console.WriteLine("{0}: {1}", frame, GetSnapshotAtFrame(frame));
        }

        static Scene GetSnapshotAtFrame(int frame)
        {
            Scene scene = new Scene(new SizeF(100, 100));
            for (int i = 0; i < frame; i++)
            {
                scene.Step();
            }
            return scene;
        }

    }
}
