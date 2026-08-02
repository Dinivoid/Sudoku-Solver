using System;

namespace Sudoku_Solver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] sudokuMatrix = new int[9, 9];
            sudokuMatrix[0, 0] = 5;
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(sudokuMatrix[i,j]);
                }
            }
        }
    }
}   