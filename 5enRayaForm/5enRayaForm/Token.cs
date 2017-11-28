using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CincoEnRaya.Model
{
    public class Token
    {
        public Player player;

        public Token(Player player)
        {
            this.player = player;
        }

        public Player Player { get { return player; } }
    }
}