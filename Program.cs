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
            int[,] result = (int[,])sudokuMatrix.Clone();
            // Matrix Variable
            bool successful = false;
            bool stepBack = false;
            bool forceWrite = false;

            (short y, short x) matrixPosition = (0, 0);
            (byte y, byte x) matrixBoxNumber = (0, 0);
            /*int matrixBoxNumberX = (matrixPosition.x / 3)*3;
            int matrixBoxNumberY = (matrixPosition.y / 3)*3;*/
            
            while (!successful)
            {
                // Check each element of the Sudoku
                for (; matrixPosition.y < 9; matrixPosition.y++)
                {
                    for (; matrixPosition.x < 9; matrixPosition.x++)
                    {
                        int x = 1;
                        matrixBoxNumber.x = (byte)((matrixPosition.x / 3) * 3);
                        matrixBoxNumber.y = (byte)((matrixPosition.y / 3) * 3);
                        
                        if (sudokuMatrix[matrixPosition.y, matrixPosition.x] != 0) // Check if default number
                        {
                            if (stepBack)
                            {
                                bool breakCycle = false;
                                for (int tY = matrixPosition.y; tY >= 0; tY--)
                                {
                                    for (int tX = matrixPosition.x; tX >= 0; tX--)
                                    {
                                        Console.WriteLine("!X! " + sudokuMatrix[tY, tX]);
                                        if (sudokuMatrix[tY, tX] != 0)
                                        {
                                            matrixPosition.x = (short)(tX - 2);
                                        }
                                        else
                                        {
                                            breakCycle = true;
                                            break;
                                        }
                                    }
                                    if (breakCycle) {break;}
                                    matrixPosition.x = 8;
                                    Console.WriteLine("*");
                                    matrixPosition.y = (short)(tY - 2);
                                }
                                /*if (matrixPosition.x > 0)
                                {
                                    matrixPosition.x -= 2;
                                }
                                else
                                {
                                    if (matrixPosition.y > 0)
                                    {
                                        matrixPosition.x = 7;
                                        matrixPosition.y--;
                                    }
                                }*/
                                forceWrite = true;
                                stepBack = false;
                            }
                            Console.WriteLine("Continue... there is a default number");
                            continue;
                        }

                        Console.WriteLine("AAA " + x);
                        if (forceWrite)
                        {
                            x = result[matrixPosition.y, matrixPosition.x] + 1;
                            forceWrite = false;
                        }
                        
                        // Continue if empty
                        
                        bool isDuplicate = false;
                        bool isAnyNumberAvaliable = false;
                        for (; x <= 9; x++) // Number selection and validation
                        {
                            // Check for vertical duplication
                            for (int yy = 0; yy < result.GetLength(0); yy++)
                            {
                                if (yy == matrixPosition.y) {continue;}
                                if (result[yy, matrixPosition.x] == x)
                                {
                                    Console.WriteLine("V: Number " + x + " duplication at " + matrixPosition.x + ":" + yy);
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
                            for (int xx = 0; xx < result.GetLength(0); xx++)
                            {
                                if (xx == matrixPosition.x) {continue;}
                                if (result[matrixPosition.y, xx] == x)
                                {
                                    Console.WriteLine("H: Number " + x + " duplication at " + xx + ":" + matrixPosition.y);
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
                                    if ((xx + matrixPosition.x) == matrixPosition.x && (yy + matrixPosition.y) == matrixPosition.y) {continue;}
                                    if (result[yy + matrixBoxNumber.y, xx + matrixBoxNumber.x] == x)
                                    {
                                        Console.WriteLine("B: Number " + x + " duplication at box " + (xx + matrixBoxNumber.x) + ":" +
                                                          (yy + matrixBoxNumber.y));
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
                            // Insert the number and continue
                            result[matrixPosition.y, matrixPosition.x] = x;
                            isAnyNumberAvaliable = true;
                            break;
                        }

                        if (!isAnyNumberAvaliable)
                        {
                            stepBack = true;
                            Console.WriteLine("Failed to get available number. Rollback");

                            if (matrixPosition.x > 0)
                            {
                                matrixPosition.x -= 2;
                            }
                            else
                            {
                                if (matrixPosition.y > 0)
                                {
                                    matrixPosition.x = 7;
                                    matrixPosition.y--;
                                }
                            }
                            
                        }
                        else
                        {
                            if (matrixPosition.x == 9 && matrixPosition.y == 9)
                            {
                                Console.WriteLine("Last number successful");
                                successful = true;
                                DrawSudoku(result);
                            }
                        }
                        Console.WriteLine("Continue. Current position: " + matrixPosition.x + ":" + matrixPosition.y);
                        DrawSudoku(result);
                    }

                    matrixPosition.x = 0;
                }
            }
        }
    }
}   