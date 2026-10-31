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
            int test_choosenElementXX = 1;
            int test_choosenElementYY = 1;
            // Number insertion
            bool isDuplicate = false;
            for (int x = 1; x <= 9; x++)
            {
                // Check for vertical duplication
                for (int yy = 0; yy < sudokuMatrix.GetLength(0); yy++)
                {
                    if (sudokuMatrix[yy, test_choosenElementXX] == x)
                    {
                        Console.WriteLine("V: Number " + x + " duplication at " + test_choosenElementXX + ":" + yy);
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
                    if (sudokuMatrix[test_choosenElementYY, xx] == x)
                    {
                        Console.WriteLine("H: Number " + x + " duplication at " + xx + ":" + test_choosenElementYY);
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    isDuplicate = false;
                    continue;
                }
                Console.WriteLine("Number " + x + " is valid");
                
                
                /*for (int xx = 0; xx < sudokuMatrix.GetLength(0); xx++)
                {
                    for (int yy = 0; yy < sudokuMatrix.GetLength(1); yy++)
                    {
                        if (sudokuMatrix[xx, yy] != 0)
                        {
                            
                        } else
                        if (sudokuMatrix[xx, yy] == x)
                        {
                            Console.WriteLine("NUMBER: " + x + " is dublicate for " + sudokuMatrix[xx, yy] + " at position " + xx + ":" + yy);
                            //break;
                        }
                    }
                }*/
            }
            // for (int i = 0; i < sudokuMatrix.GetLength(0); i++)
            // {
            //     
            // }
        }
    }
}   