﻿namespace KingSurvival
{
    using System;

    public class GameBoard
    {
        // fileds
        private static readonly char[,] board = 
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        private static readonly int[,] boardCorners = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }
        };


        public static int[,] BoardCorners
        {
            get
            {
                return boardCorners;
            }
        }

        public static char[,] Board
        {
            get
            {
                return board;
            }
        }

        // methods
        public static void ShowBoard()
        {
            // TODO: Fix a bug thats not showing the illegal move message
            //// After every figure move clear console
            //Console.Clear();

            // This will print empty line on console
            Console.WriteLine();

            // Make board colorful
            for (int row = 0; row < GameBoard.Board.GetLength(0); row++)
            {
                for (int col = 0; col < GameBoard.Board.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = GameBoard.CheckPositionInBoard(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                PrintGreenSquareWithBlackFont(row, col);
                            }
                            else if (col % 2 == 0)
                            {
                                PrintBlueSquareWithBlackFont(row, col);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(GameBoard.Board[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            PrintBlueSquareWithBlackFont(row, col);
                        }
                        else if (col % 2 == 0)
                        {
                            PrintGreenSquareWithBlackFont(row, col);
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(GameBoard.Board[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(GameBoard.Board[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public static bool CheckPositionInBoard(int[] positionCoodinates)
        {
            int positonRow = positionCoodinates[0];
            bool isRowInBoard = (positonRow >= GameBoard.BoardCorners[0, 0]) && (positonRow <= GameBoard.BoardCorners[3, 0]);
            int positonCol = positionCoodinates[1];
            bool isColInBoard = (positonCol >= GameBoard.BoardCorners[0, 1]) && (positonCol <= GameBoard.BoardCorners[3, 1]);
            return isRowInBoard && isColInBoard;
        }

        private static void PrintBlueSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(GameBoard.Board[row, col]);
            Console.ResetColor();
        }

        private static void PrintGreenSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(GameBoard.Board[row, col]);
            Console.ResetColor();
        }
    }
}
