using System;

namespace Codingame.Puzzle.SudokuValidator
{ 
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
    public class Solution
    {
        static void Run(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                for (int j = 0; j < 9; j++)
                {
                    int n = int.Parse(inputs[j]);
                }
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("true or false");
        }
    }
}