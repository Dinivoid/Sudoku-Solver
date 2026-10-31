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
            BruteForce(sudokuVariant1);
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
        /// First method of solving the sudoku - Brute Force it
        static void BruteForce(int[,] sudokuMatrix)
        {
            // Debug variables
            int test_choosenElementXx = 0;
            int test_choosenElementYy = 0;
            
            // Matrix Variable
            int matrixBoxNumberX = (test_choosenElementXx / 3)*3;
            int matrixBoxNumberY = (test_choosenElementYy / 3)*3;
            
            // Number insertion
            bool isDuplicate = false;
            for (int x = 1; x <= 9; x++)
            {
                // Check for vertical duplication
                for (int yy = 0; yy < sudokuMatrix.GetLength(0); yy++)
                {
                    if (sudokuMatrix[yy, test_choosenElementXx] == x)
                    {
                        Console.WriteLine("V: Number " + x + " duplication at " + test_choosenElementXx + ":" + yy);
                        isDuplicate = true;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    isDuplicate = false;
                    continue;
                }
                // Check for horizontal duplication
                for (int xx = 0; xx < sudokuMatrix.GetLength(0); xx++)
                {
                    if (sudokuMatrix[test_choosenElementYy, xx] == x)
                    {
                        Console.WriteLine("H: Number " + x + " duplication at " + xx + ":" + test_choosenElementYy);
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    isDuplicate = false;
                    continue;
                }
                // Check the box where the chosen element
                for (int yy = 0; yy < 3; yy++)
                {
                    for (int xx = 0; xx < 3; xx++)
                    {
                        if (sudokuMatrix[yy + matrixBoxNumberY, xx + matrixBoxNumberX] == x)
                        {
                            Console.WriteLine("B: Number " + x + " duplication at box " + (xx + matrixBoxNumberX) + ":" +
                                              (yy + matrixBoxNumberY));
                            isDuplicate = true;
                            break;
                        }
                    }
                }
                if (isDuplicate)
                {
                    isDuplicate = false;
                    continue;
                }
                Console.WriteLine("Number " + x + " is valid");
            }
        }
    }
}   