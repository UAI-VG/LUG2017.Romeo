﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class SimulationViewer : Form
    {
        private const int scale = 5;
        private Scene currentScene = null;
        private Dictionary<int, Scene> cache = new Dictionary<int, Scene>();
        bool check = false;

        public SimulationViewer()
        {
            InitializeComponent();
        }

        private void SimulationViewer_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.UserPaint 
                | ControlStyles.AllPaintingInWmPaint, true);
            
                updateTimer.Enabled = true;
            InicializarCache(trackBar1.Value);
        }

        int CalcularBegin(int frame)
        {
            if (frame == 0) return 0;
            int begin = frame - 1;

            if (cache.ContainsKey(begin))
            {
                return begin;
            }
            else
            {
                CalcularBegin(begin);
            }

            int newBegin = new int();
            newBegin = begin;
            return newBegin;
        }

        private Scene InicializarCache(int frame)
        {
            if (cache.ContainsKey(frame)) return cache[frame];
            Scene scene = null;
            scene = new Scene(new SizeF(100, 100));
           
            int begin = 0;

            if (!check)
            {
                for (int i = 0; i < 2000001; i++)
                {
                    scene.Step();
                    if (i == 0 || i % 1000 == 0 && !cache.ContainsKey(i))
                        cache.Add(i, scene.Clone());
                }
                check = true;
            }

            if (cache.Count > 0)
            {
                begin = CalcularBegin(frame);
                scene = cache[begin];
            }

            for (int i = begin; i < frame; i++)
            {
                scene.Step();
            }

            scene = cache[frame];
            return scene;
        }

        Scene GetSnapshotAtFrame(int frame)
        {
            if (cache.ContainsKey(frame)) return cache[frame];

            Scene scene = null;
            int begin = 0;

            if (cache.Count == 0)
            {
                begin = 0;
                scene = new Scene(new SizeF(100, 100));
            }
            else
            {
                begin = cache.Keys.Count;
                scene = cache[begin];
            }

            for (int i = begin; i < frame; i++)
            {
                scene.Step();

                if (i == 0 || i % 1000 == 0)
                cache.Add(frame, scene.Clone());
            }
            check = true;
            return scene;
        }


        private void SimulationViewer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, Width, Height));

            if (currentScene != null)
            {
                foreach (Ball ball in currentScene.Entities)
                {
                    float x = scale * ball.Position.X;
                    float y = scale * ball.Position.Y;
                    float w = scale * (float)ball.Radius;
                    float h = scale * (float)ball.Radius;
                    g.FillEllipse(Brushes.Red, new RectangleF(x, y , w, h));
                }
            }
            
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {                
            Refresh();        
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentScene = InicializarCache(trackBar1.Value);
            label1.Text = currentScene.ToString();
            label2.Text = trackBar1.Value.ToString();
        }
    }
}
