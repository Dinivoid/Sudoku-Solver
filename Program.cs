using System;

namespace Sudoku_Solver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] sudokuVariant1 = new int[,]
            {
                { 0, 8, 0, 2, 0, 9, 0, 5, 0 },
                { 0, 7, 1, 0, 0, 0, 3, 8, 0 },
                { 0, 0, 5, 0, 3, 0, 7, 0, 0 },

                { 4, 0, 0, 8, 6, 2, 0, 0, 5 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 8, 0, 0, 7, 1, 5, 0, 0, 2 },

                { 0, 0, 6, 0, 8, 0, 2, 0, 0 },
                { 0, 2, 4, 0, 0, 0, 5, 7, 0 },
                { 0, 1, 0, 5, 0, 4, 0, 9, 0 },
            };
            int[,] sudokuMatrix = new int[9, 9];
            
            DrawSudoku(sudokuVariant1);
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