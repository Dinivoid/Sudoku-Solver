using System;

namespace Sudoku_Solver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Test Sudoku Matrix for debug etc
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
            // Main sudoku matrix to work with the code
            int[,] sudokuMatrix = new int[9, 9];
            
            DrawSudoku(sudokuVariant1);
        }

        // Function to draw sudoku in the cmd
        static void DrawSudoku(int[,] sudokuMatrix)
        {
            // Draw horizontal of the matrix
            for (int i = 0; i < 9; i++)
            {
                Console.Write("| ");
                // Draw each number of the horizontal
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudokuMatrix[i,j] + " ");
                    // Draw visual separation after third number
                    if ((j+1) % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                }
                // After three horizontals write visual horizontal separation
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