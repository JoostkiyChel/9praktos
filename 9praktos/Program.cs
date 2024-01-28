using _9praktos;
using System;
using System.Collections.Generic;
using System.Threading;

public enum MapSize
{
    MaxRightBorder = 31,
    MaxLowerBorder = 21
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Game game = new Game();
        game.Play();
        Console.WriteLine("Game Over!");
        Console.ReadLine();
    }
}

