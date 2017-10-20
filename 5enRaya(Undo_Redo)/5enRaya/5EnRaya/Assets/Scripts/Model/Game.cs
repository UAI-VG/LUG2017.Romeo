using System;
using System.Collections;
using System.Collections.Generic;

public class Game
{
    private Board board;
    private Player[] players;
    private int turn = 0;
    public Token token { get; set; } 
    public int column { get; set; }

    
    // Undo/Redo_________________________________________________________________________

    private Stack<Command> doneCommands = new Stack<Command>();
    private Stack<Command> UndoneCommands = new Stack<Command>();

    public void Do(Command Jugada)
    {
        Jugada.Do();
        doneCommands.Push(Jugada);
        UndoneCommands.Clear();
    }

    public void Undo()
    {
        if (doneCommands.Count <= 0) return;
        Command Move = doneCommands.Pop();
        Move.Undo();
        UndoneCommands.Push(Move);
        PreviousTurn();
    }

    public void Redo()
    {
        if (UndoneCommands.Count <= 0) return;
        Command Jugada = UndoneCommands.Pop();
        Jugada.Do();
        doneCommands.Push(Jugada);
    }

    //_________________________________________________________________________________

    public Game(Board board, Player[] players)
    {
        this.board = board;
        this.players = players;
    }

    public Board Board { get { return board; } }
    public IEnumerable<Player> Players { get { return players; } }
    public int Turn { get { return turn; } }
    public Player CurrentPlayer { get { return players[turn]; } }
    
    public int IndexOfPlayer(Player player)
    {
        return Array.IndexOf(players, player);
    }

    public void Play(int column)
    {
        try
        {
            Do(CurrentPlayer.Play(column, board));
            NextTurn();
        }
        catch (InvalidOperationException)
        {
            // Do nothing
        }
    }

    private void NextTurn()
    {
        turn = (turn + 1) % players.Length;
    }

    private void PreviousTurn()
    {
        turn = ((turn - 1) + players.Length) % players.Length;
    }
}
