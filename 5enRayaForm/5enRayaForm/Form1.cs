using CincoEnRaya.Model;
using CincoEnRaya.Model.Strategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5enRayaForm
{
    public partial class Form1 : Form
    {
        private static Game game;
        public Form1()
        {
            InitializeComponent();
        }

        private void InicializarTodo()
        {
            Board board = new Board(8, 6);
            Player[] players = new Player[]
            {
            new Player("Human",
                new NullStrategy()),
            new Player("CPU",
                new AggressiveStrategy(
                    5,
                    new DefensiveStrategy(
                        new AggressiveStrategy(
                            4,
                            new AggressiveStrategy(
                                3,
                                new AggressiveStrategy(
                                    2,
                                    new RandomStrategy())))))),
            };
            game = new Game(board, players);
            game.TurnEnded += mETODOcUALQUIERA;
            game.NextTurn();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            e.Graphics.FillRectangle(Brushes.Yellow, 0,0,Width, Height);
            Casillero C = new Casillero();
            C.Dibujar(e.Graphics,game.Board,25,35,50,50);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicializarTodo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Play(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Play(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.Play(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.Play(3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            game.Play(4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            game.Play(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            game.Play(6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            game.Play(7);
        }

        private void mETODOcUALQUIERA()
        {
            game.NextTurn();
        }
    }
}
