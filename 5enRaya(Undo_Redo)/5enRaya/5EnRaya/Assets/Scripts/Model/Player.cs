﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player
{
    private string name;

    public Player(string name)
    {
        this.name = name;
    }

    public string Name { get { return name; } }

    public Command Play(int column, Board board)
    {
        Token token = new Token(this);
        Command Move = new Command(token, column, board);

        return Move;
    }
}
