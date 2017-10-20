using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    private Token[] tokens;
    public Board board;
    public Token token { get; set; }
    public int column { get; set; }

    public Command(Token token, int column, Board board)
    {
        this.token = token;
        this.column = column;
        this.board = board;
    }

    public void Do()
    {
        board.Put(token, column);
    }

    public void Undo()
    {
        board.UnPuT(column);
    }
}
