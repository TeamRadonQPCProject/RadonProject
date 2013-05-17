//-----------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main game logic.
    /// </summary>
    public class GameEngine
    {
        // fileds
        private readonly List<Figure> allPawns;
        private int movementsCounter = 0; 
        private bool gameIsFinished = false;
        private readonly GameBoard kingSurvivalGameBoard;
        private readonly Pawn firstPawn;
        private readonly Pawn secondPawn;
        private readonly Pawn thirdPawn;
        private readonly Pawn fourthPawn;
        private readonly King theKing;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class with all its needed components.
        /// </summary>
        /// <param name="kingSurvivalGameBoard">Takes the game board.</param>
        /// <param name="firstPawn">Takes the games first pawn.</param>
        /// <param name="secondPawn">Takes the games second pawn.</param>
        /// <param name="thirdPawn">Takes the games third pawn.</param>
        /// <param name="fourthPawn">Takes the games fourth pawn.</param>
        /// <param name="theKing">Takes the games king.</param>
        public GameEngine(GameBoard kingSurvivalGameBoard, Pawn firstPawn, Pawn secondPawn, Pawn thirdPawn, Pawn fourthPawn, King theKing)
        {
            this.kingSurvivalGameBoard = kingSurvivalGameBoard;
            this.firstPawn = firstPawn;
            this.secondPawn = secondPawn;
            this.thirdPawn = thirdPawn;
            this.fourthPawn = fourthPawn;
            this.theKing = theKing;
            this.allPawns = new List<Figure>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is finished or not.
        /// </summary>
        /// <value>The game's state.</value>
        public bool GameIsFinished
        {
            get
            {
                return this.gameIsFinished;
            }

            set
            {
                this.gameIsFinished = value;
            }
        }

        /// <summary>
        /// Gets or sets the movement counter.
        /// </summary>
        /// <value>The game's movement counter.</value>
        public int MovementsCounter
        {
            get
            {
                return this.movementsCounter;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The movement counter can not be negative!");
                }

                this.movementsCounter = value;
            }
        }

        #region COMMAND PROCESS

        /// <summary>
        /// Handles turn processing.
        /// </summary>
        public void StartNextTurn()
        {
            if (this.GameIsFinished)
            {
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (this.MovementsCounter % 2 == 0)
                {
                    int currentKingXAxe = this.theKing.FigurePosition[0];
                    bool isKingExit = this.CheckForKingExit(currentKingXAxe);
                    if (isKingExit)
                    {
                        Console.WriteLine("End!");
                        Console.WriteLine("King wins in {0} moves!", this.MovementsCounter / 2);
                        this.GameIsFinished = true;
                    }

                    if (this.GameIsFinished != true)
                    {
                        this.ShowCurrentBoard();
                        this.ValidateKingsCommand();
                        this.MovementsCounter++;
                        this.StartNextTurn();
                    }
                }
                else
                {
                    this.ShowCurrentBoard();
                    this.ValidatePawnCommand();
                }
            }
        }

        /// <summary>
        /// Starts the current game by adding all the pawns.
        /// </summary>
        public void StartGame()
        {
            this.allPawns.Add(this.firstPawn);
            this.allPawns.Add(this.secondPawn);
            this.allPawns.Add(this.thirdPawn);
            this.allPawns.Add(this.fourthPawn);
        }

        /// <summary>
        /// Shows the currents state of the board.
        /// </summary>
        public void ShowCurrentBoard()
        {
            this.kingSurvivalGameBoard.ShowBoard();
        }

        /// <summary>
        /// Checks if a given command is a valid input for the current figure.
        /// </summary>
        /// <param name="gameCommand">Takes a command string.</param>
        /// <param name="currentFigureValidInput">Takes the valid console inputs for the current figure.</param>
        /// <returns>Returns if the given input is valid for the given figure.</returns>
        public bool ChechInputForGivenFigure(string gameCommand, string[] currentFigureValidInput)
        {
            bool hasAnEqual = false;

            int[] validInputs = new int[currentFigureValidInput.Length];

            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                string figureValidInputsToCheck = currentFigureValidInput[i];
                int result = gameCommand.CompareTo(figureValidInputsToCheck);

                if (result != 0)
                {
                    validInputs[i] = 0;
                }
                else
                {
                    validInputs[i] = 1;
                }
            }

            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                if (validInputs[i] == 1)
                {
                    hasAnEqual = true;
                    break;
                }
            }

            // write on console if there is no valid input
            if (!hasAnEqual)
            {
                ConsoleWriter.WriteInvalidCommand();
            }

            return hasAnEqual;
        }

        #endregion

        #region KING LOGIC

        /// <summary>
        /// Validates the kings command.
        /// </summary>
        public void ValidateKingsCommand()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = this.ReadKingInput();

                if (string.IsNullOrEmpty(input))
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
                else
                {
                    input = input.ToUpper();
                    if (this.ChechInputForGivenFigure(input, this.theKing.ValidFigureInputs))
                    {
                        this.SetNewKingPosition(input);
                        isExecuted = true;
                    }
                }
            }
        }

        /// <summary>
        /// Check if the king has existing turns.
        /// </summary>
        /// <param name="currentCoords">The kings current coordinates.</param>
        /// <returns>Returns true if the king has valid moves or false if he does not.</returns>
        public bool HasKingExistingMove(int[] currentCoords)
        {
            int[] newCoords = new int[2];
            int[,] displacements = 
            {
                { 1, -2 },
                { 1, 2 },
                { -1, -2 },
                { -1, 2 },
            };

            bool allAreFalse = true;
            try
            {
                for (int i = 0; i < displacements.GetLength(0); i++)
                {
                    newCoords[0] = currentCoords[0] + displacements[i, 0];
                    newCoords[1] = currentCoords[1] + displacements[i, 1];
                    if (!(this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
                    {
                        this.theKing.FigureExistingMoves[i] = false;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (this.theKing.FigureExistingMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }
            }
            catch (IndexOutOfRangeException iore)
            {
                throw new IndexOutOfRangeException("King availible moves are only four and you try to access nonexisting value. \n{0}", iore);
            }

            if (allAreFalse)
            {
                return false;
                ////this.GameIsFinished = true;
                ////Console.WriteLine("King loses!");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the king has won.
        /// </summary>
        /// <param name="currentKingXAxe">Takes the King's x coordinates.</param>
        /// <returns>Returns if the king has won.</returns>
        public bool CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe < 2 || currentKingXAxe > 10)
            {
                throw new ArgumentOutOfRangeException("King is out of board boundaries.");
            }

            if (currentKingXAxe == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the new position of the King.
        /// </summary>
        /// <param name="gameCommand">Takes a valid console command.</param>
        public void SetNewKingPosition(string gameCommand)
        {
            int[] oldCoordinates = new int[2];

            oldCoordinates[0] = this.theKing.FigurePosition[0];
            oldCoordinates[1] = this.theKing.FigurePosition[1];

            int[] newCoords = new int[2];
            newCoords = this.GetNewKingCoords(oldCoordinates, gameCommand);

            if (newCoords != null)
            {
                this.theKing.FigurePosition[0] = newCoords[0];
                this.theKing.FigurePosition[1] = newCoords[1];
            }
            else
            {
                this.ValidateKingsCommand();
            }
        }

        /// <summary>
        /// Gets the new coordinates of the King.
        /// </summary>
        /// <param name="currentCoordinates">Takes the King's current coordinates.</param>
        /// <param name="gameCommand">Takes a valid console command.</param>
        /// <returns>Returns the new coordinates of the King.</returns>
        private int[] GetNewKingCoords(int[] currentCoordinates, string gameCommand)
        {
            int[] newCoords = new int[2];
            int[] displacementDirection = new int[2];

            string direction = gameCommand[1].ToString() + gameCommand[2].ToString();
            switch (direction)
            {
                case "DL":
                    displacementDirection[0] = 1;
                    displacementDirection[1] = -2;
                    break;
                case "DR":
                    displacementDirection[0] = 1;
                    displacementDirection[1] = 2;
                    break;
                case "UL":
                    displacementDirection[0] = -1;
                    displacementDirection[1] = -2;
                    break;
                case "UR":
                    displacementDirection[0] = -1;
                    displacementDirection[1] = 2;
                    break;
                default:
                    return null;
            }

            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];

            if (this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                this.MoveKingOnBoard(currentCoordinates, newCoords);
                return newCoords;
            }
            else
            {
                ConsoleWriter.WriteWrongDirection();
                return null;
            }
        }

        /// <summary>
        /// Move the King figure on the game board.
        /// </summary>
        /// <param name="currentCoordinates">Takes the King's current coordinates.</param>
        /// <param name="newCoords">Takes the King's new coordinates.</param>
        private void MoveKingOnBoard(int[] currentCoordinates, int[] newCoords)
        {
            char sign = this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
            this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
            this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    this.theKing.FigureExistingMoves[i] = true;
                }
            }
            catch (IndexOutOfRangeException iore)
            {
                throw new IndexOutOfRangeException("King availible moves are only four and you try to access nonexisting value. \n{0}", iore);
            }
        }

        /// <summary>
        /// Move the Pawn figure on the game board.
        /// </summary>
        /// <param name="newCoords">Takes the Pawn's new coordinates.</param>
        /// <param name="currentCoordinates">Takes the Pawn's current coordinates.</param>
        /// <param name="currentPawnSign">Takes the current pawn sign.</param>
        /// <returns>Returns if the move is successful.</returns>
        private bool MovePawnOnBoard(int[] newCoords, int[] currentCoordinates, char currentPawnSign)
        {
            bool figureIsMoved = false;

            if (this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;

                for (int i = 0; i < this.allPawns.Count; i++)
                {
                    if (this.allPawns[i].FigureSign == currentPawnSign)
                    {
                        this.allPawns[i].FigureExistingMoves[0] = true;
                        this.allPawns[i].FigureExistingMoves[1] = true;
                        figureIsMoved = true;
                        break;
                    }
                }

                return figureIsMoved;
            }
            else
            {
                for (int i = 0; i < this.allPawns.Count; i++)
                {
                    if (this.allPawns[i].FigureSign == currentPawnSign)
                    {
                        this.allPawns[i].FigureExistingMoves[0] = false;
                        this.allPawns[i].FigureExistingMoves[1] = false;
                        figureIsMoved = false;
                        break;
                    }
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();

                return figureIsMoved;
            }
        }

        ////private int indexKing = 0;

        public virtual string ReadKingInput()
        {
            ////string[] sampleInput = new string[] {
            ////"kur",
            ////"kur",
            ////"kul",
            ////"kdr",
            ////"kdr",
            ////"kdr"
            ////};
            ////string[] sampleInput = new string[] {
            ////"kur",
            ////"kur",
            ////"kur",
            ////"kur",
            ////"kul",
            ////"kul",
            ////"kur"
            ////};
            ////// Test all pawns down
            ////string[] sampleInput = new string[] {
            ////"kur",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kur",
            ////"kdl",
            ////"kul",
            ////"kul",
            ////"kul",
            ////"kdr",
            ////"kul",
            ////"kdr",
            ////"kul",
            ////"kdr",
            ////"kul",
            ////"kdr",
            ////"kul",
            ////"kdr",
            ////"kul"
            ////};
            ////if (indexKing < sampleInput.Length)
            ////{
            ////    //Console.WriteLine(indexKing);
            ////    Console.WriteLine(sampleInput[indexKing]);
            ////    return sampleInput[indexKing++];
            ////}
            string kingInput = Console.ReadLine();
            return kingInput;
        }

#endregion

        #region PAWN LOGIC

        /// <summary>
        /// Validates the pawn input.
        /// </summary>
        public void ValidatePawnCommand()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = this.ReadPawnInput();

                if (string.IsNullOrEmpty(input))
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
                else
                {
                    input = input.ToUpper();
                    if (this.CheckPawnPlayerInput(input))
                    {
                        this.SetNewPawnPosition(input);
                        isExecuted = true;
                    }
                }
            }

            bool hasKingExistingMove = this.HasKingExistingMove(this.theKing.FigurePosition);
            if (hasKingExistingMove == false)
            {
                this.GameIsFinished = true;
                Console.WriteLine("King loses!");
            }

            this.HasPawnsExistingMove();
            this.StartNextTurn();
        }

        /// <summary>
        /// Checks if the player input for pawn is correct.
        /// </summary>
        /// <param name="stringToCheck">Takes a game command to check.</param>
        /// <returns>Returns if the given command was valid.</returns>
        public bool CheckPawnPlayerInput(string stringToCheck)
        {
            char startLetter = stringToCheck[0];
            bool isCommandValid = true;

            switch (startLetter)
            {
                case 'A':
                    isCommandValid = this.ChechInputForGivenFigure(stringToCheck, this.firstPawn.ValidFigureInputs);
                    break;
                case 'B':
                    isCommandValid = this.ChechInputForGivenFigure(stringToCheck, this.secondPawn.ValidFigureInputs);
                    break;
                case 'C':
                    isCommandValid = this.ChechInputForGivenFigure(stringToCheck, this.thirdPawn.ValidFigureInputs);
                    break;
                case 'D':
                    isCommandValid = this.ChechInputForGivenFigure(stringToCheck, this.fourthPawn.ValidFigureInputs);
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                    isCommandValid = false;
                    break;
            }

            return isCommandValid;
        }

        /// <summary>
        /// Sets the new position to the Pawn figure.
        /// </summary>
        /// <param name="gameCommand">Takes a valid game command.</param>
        /// <returns>Returns if the position set was successful.</returns>
        private bool SetNewPawnPosition(string gameCommand)
        {
            char figure = gameCommand[0];
            int[] coords = new int[3];

            for (int i = 0; i < this.allPawns.Count; i++)
            {
                if (this.allPawns[i].FigureSign == figure)
                {
                    coords = this.allPawns[i].GetFigureNewCoords(gameCommand);

                    if (this.MovePawnOnBoard(coords, this.allPawns[i].FigurePosition, figure))
                    {
                        this.allPawns[i].FigurePosition[0] = coords[0];
                        this.allPawns[i].FigurePosition[1] = coords[1];
                    }
                    else
                    {
                        this.ValidatePawnCommand();
                    }

                    break;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the pawns have more existing moves.
        /// </summary>
        public void HasPawnsExistingMove()
        {
            bool allAreFalse = true;
            int[,] displasment = 
            {
                { 1, -2 },
                { 1, 2 }
            };

            try
            {
                int[] newCoords = new int[2];
                for (int i = 0; i < this.allPawns.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        newCoords[0] = this.allPawns[i].FigurePosition[0] + displasment[j, 0];
                        newCoords[1] = this.allPawns[i].FigurePosition[1] + displasment[j, 1];
                        if (!(this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
                        {
                            this.allPawns[i].FigureExistingMoves[j] = false;
                        }
                    }
                }

                for (int i = 0; i < this.allPawns.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (this.allPawns[i].FigureExistingMoves[j] == true)
                        {
                            allAreFalse = false;
                            break;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException iore)
            {
                throw new IndexOutOfRangeException("Pawn availible moves are only two and you try to access nonexisting value. {0}", iore);
            }

            if (allAreFalse)
            {
                Console.WriteLine("King wins!");
                this.GameIsFinished = true;
            }
        }

        ////private int indexPawn = 0;

        public virtual string ReadPawnInput()
        {
            ////Pawns win, king is in down right corner
            ////string[] sampleInput = new string[] {
            ////"cdr",
            ////"cdr",
            ////"cdl",
            ////"cdr",
            ////"cdr",
            ////"cdl"
            ////};
            //////King win
            ////string[] sampleInput = new string[]
            ////{
            ////    "ddl",
            ////    "ddl",
            ////    "ddl",
            ////    "ddl",
            ////    "ddl",
            ////    "ddl",
            ////    "ddr"
            ////};
            ////// Test all pawns down
            ////string[] sampleInput = new string[] {
            ////"adr",
            ////"adl",
            ////"adr",
            ////"adl",
            ////"adr",
            ////"adl",
            ////"adr",
            ////"bdr",
            ////"bdl",
            ////"bdr",
            ////"bdl",
            ////"bdr",
            ////"bdl",
            ////"bdr",
            ////"cdr",
            ////"cdl",
            ////"cdr",
            ////"cdl",
            ////"cdr",
            ////"cdl",
            ////"cdr",
            ////"ddr",
            ////"ddl",
            ////"ddr",
            ////"ddl",
            ////"ddr",
            ////"ddl",
            ////"ddr",
            ////};
            ////if (indexPawn < sampleInput.Length)
            ////{
            ////    //Console.WriteLine(indexPawn);
            ////    Console.WriteLine(sampleInput[indexPawn]);
            ////    return sampleInput[indexPawn++];
            ////}
            string pawnInput = Console.ReadLine();
            return pawnInput;
        }

        #endregion
    }
}