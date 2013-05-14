//-----------------------------------------------------------------------
// <copyright file="GameBoard.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for Kings Survival game board.
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// The game boards corners.
        /// </summary>
        private readonly int[,] boardCorners = 
        {
            { 2, 4 }, 
            { 2, 18 }, 
            { 9, 4 }, 
            { 9, 18 }
        };

        /// <summary>
        /// The game boards contents.
        /// </summary>
        private readonly char[,] board = 
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

        /// <summary>
        /// Gets the game board contents.
        /// </summary>
        /// <value>The game board contents.</value>
        public char[,] Board
        {
            get
            {
                return this.board;
            }
        }

        /// <summary>
        /// Draws the game board on the console.
        /// </summary>
        public void ShowBoard()
        {
            // After every figure move clear console
            Console.Clear();

            // This will print empty line on top of board
            Console.WriteLine();

            // Make board colorful
            for (int row = 0; row < this.Board.GetLength(0); row++)
            {
                for (int col = 0; col < this.Board.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = this.CheckPositionInBoard(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                this.PrintGreenSquareWithBlackFont(row, col);
                            }
                            else if (col % 2 == 0)
                            {
                                this.PrintBlueSquareWithBlackFont(row, col);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(this.Board[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            this.PrintBlueSquareWithBlackFont(row, col);
                        }
                        else if (col % 2 == 0)
                        {
                            this.PrintGreenSquareWithBlackFont(row, col);
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(this.Board[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(this.Board[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Checks if a given position is within the game board.
        /// </summary>
        /// <param name="positionCoordinates">Takes a valid set of coordinates.</param>
        /// <returns>Returns a <see cref="System.Boolean"/> variable if the position is in the board or if its not.</returns>
        public bool CheckPositionInBoard(int[] positionCoordinates)
        {
            int positonRow = positionCoordinates[0];

            bool isRowInBoard =
                (positonRow >= this.boardCorners[0, 0]) &&
                (positonRow <= this.boardCorners[3, 0]);

            int positonCol = positionCoordinates[1];

            bool isColInBoard =
                (positonCol >= this.boardCorners[0, 1]) &&
                (positonCol <= this.boardCorners[3, 1]);

            return isRowInBoard && isColInBoard;
        }

        /// <summary>
        /// A helper method the prints blue squares with black font on the <see cref="System.Console"/>.
        /// </summary>
        /// <param name="row">Takes a valid game board row coordinate.</param>
        /// <param name="col">Takes a valid game board column coordinate.</param>
        private void PrintBlueSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(this.Board[row, col]);
            Console.ResetColor();
        }

        /// <summary>
        /// A helper method the prints green squares with black font on the <see cref="System.Console"/>.
        /// </summary>
        /// <param name="row">Takes a valid game board row coordinate.</param>
        /// <param name="col">Takes a valid game board column coordinate.</param>
        private void PrintGreenSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(this.Board[row, col]);
            Console.ResetColor();
        }
    }
}
