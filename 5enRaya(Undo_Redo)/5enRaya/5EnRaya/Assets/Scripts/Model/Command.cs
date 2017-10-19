using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    private Token[] tokens;
    public Board Tablero;
    private Token token;
    private int column;

    public Command(Token token, int column)
    {
        this.token = token;
        this.column = column;
    }

    public void Do()
    {
        Tablero.Put(token, column);
    }

    public void Undo()
    {


    }
}
