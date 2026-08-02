using System;

namespace Sudoku_Solver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] sudokuMatrix = new int[9, 9];
            
            DrawSudoku(sudokuMatrix);
        }

        static void DrawSudoku(int[,] sudokuMatrix)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudokuMatrix[i,j] + " ");
                    if ((j+1) % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
                if ((i+1) % 3 == 0)
                {
                    Console.Write("— — — — — — — — — — — — — ");
                    Console.WriteLine();
                }
            }
        }
    }
}   