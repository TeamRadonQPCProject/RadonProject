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
        private int movementsCounter = 0;
        private bool gameIsFinished = false;
        private GameBoard kingSurvivalGameBoard;
        private PawnA firstPawn;
        private PawnB secondPawn;
        private PawnC thirdPawn;
        private PawnD fourthPawn;
        private King theKing;
        private readonly List<Figure> allPawns;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class with all its needed components.
        /// </summary>
        /// <param name="kingSurvivalGameBoard">Takes the game board.</param>
        /// <param name="firstPawn">Takes the games first pawn.</param>
        /// <param name="secondPawn">Takes the games second pawn.</param>
        /// <param name="thirdPawn">Takes the games third pawn.</param>
        /// <param name="fourthPawn">Takes the games fourth pawn.</param>
        /// <param name="theKing">Takes the games king.</param>
        public GameEngine(GameBoard kingSurvivalGameBoard, PawnA firstPawn, PawnB secondPawn, PawnC thirdPawn, PawnD fourthPawn, King theKing)
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

        // methods

        /* COMMAND PROCESS */

        /// <summary>
        /// Handles turn processing.
        /// </summary>
        public void InteractWithUser()
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
                        this.ProcessKingSide();
                        this.MovementsCounter++;
                        this.InteractWithUser();
                    }
                }
                else
                {
                    this.ShowCurrentBoard();
                    this.ProcessPawnSide();
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
        /// Checks if the game input is correct.
        /// </summary>
        /// <param name="stringToCheck">Takes a game command.</param>
        /// <returns>Returns a <see cref="System.Boolean"/>.</returns>
        public bool CheckPlayerInput(string stringToCheck)
        {
            char startLetter = stringToCheck[0];
            switch (startLetter)
            {
                case 'A':
                    return this.ChechInput(stringToCheck, this.firstPawn.ValidFigureInputs);

                case 'B':
                    return this.ChechInput(stringToCheck, this.secondPawn.ValidFigureInputs);

                case 'C':
                    return this.ChechInput(stringToCheck, this.thirdPawn.ValidFigureInputs);

                case 'D':
                    return this.ChechInput(stringToCheck, this.fourthPawn.ValidFigureInputs);

                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                    return false;
            }
        }

        public bool ChechInput(string checkedString, string[] currentFigureValidInput)
        {
            bool hasAnEqual = false;

            int[] validInputs = new int[currentFigureValidInput.Length];

            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                string figureValidInputsToCheck = currentFigureValidInput[i];
                int result = checkedString.CompareTo(figureValidInputsToCheck);

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
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command name!");
                Console.ResetColor();
            }

            return hasAnEqual;
        }

        public bool ProcessCommand(string checkedInput)
        {
            bool isCommandNameCorrect = this.CheckPlayerInput(checkedInput);

            if (isCommandNameCorrect)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        return this.MovePawn(checkedInput);

                    case 'B':
                        return this.MovePawn(checkedInput);

                    case 'C':
                        return this.MovePawn(checkedInput);

                    case 'D':
                        return this.MovePawn(checkedInput);

                    default:
                        throw new ArgumentException("Input command start was invalid!");
                }
            }
            else
            {
                return false;
            }
        }

        /* KING LOGIC - moved to class King*/

        public void ProcessKingSide()
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
                    isExecuted = this.ProcessKingCommand(input);
                }
            }
        }

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

            for (int i = 0; i < displacements.GetLength(0); i++)
            {
                newCoords[0] = currentCoords[0] + displacements[i, 0];
                newCoords[1] = currentCoords[1] + displacements[i, 1];
                if (!(this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
                {
                    this.theKing.FigureExistingMoves[i] = false;
                }
            }

            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (this.theKing.FigureExistingMoves[i] == true)
                {
                    allAreFalse = false;
                }
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

        public bool CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ProcessKingCommand(string checkedInput)
        {
            bool isCommandNameCorrect = this.ChechInput(checkedInput, this.theKing.ValidFigureInputs);

            if (isCommandNameCorrect)
            {
                if (checkedInput[1] == 'U')
                {
                    if (checkedInput[2] == 'L')
                    {
                        this.MoveKing('U', 'L');
                    }
                    else
                    {
                        this.MoveKing('U', 'R');
                    }

                    return true;
                }
                else
                {
                    if (checkedInput[2] == 'L')
                    {
                        this.MoveKing('D', 'L');
                    }
                    else
                    {
                        this.MoveKing('D', 'R');
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void MoveKing(char firstDirection, char secondDirection)
        {
            int[] oldCoordinates = new int[2];

            oldCoordinates[0] = this.theKing.FigurePosition[0];
            oldCoordinates[1] = this.theKing.FigurePosition[1];

            int[] newCoords = new int[2];
            newCoords = this.CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection);

            if (newCoords != null)
            {
                this.theKing.FigurePosition[0] = newCoords[0];
                this.theKing.FigurePosition[1] = newCoords[1];
            }
            else
            {
                this.ProcessKingSide();
            }
        }

        private int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };

            string direction = firstDirection.ToString() + secondDirection.ToString();
            switch (direction)
            {
                case "UL":
                    return this.CheckKingAvailableMove(currentCoordinates, displacementUpLeft);
                case "UR":
                    return this.CheckKingAvailableMove(currentCoordinates, displacementUpRight);
                case "DL":
                    return this.CheckKingAvailableMove(currentCoordinates, displacementDownLeft);
                case "DR":
                    return this.CheckKingAvailableMove(currentCoordinates, displacementDownRight);
                default:
                    return null;
            }
        }

        private int[] CheckKingAvailableMove(int[] currentCoordinates, int[] displacementDirection)
        {
            int[] newCoords = new int[2];
            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];
            if (this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                return this.MoveKingOnBoard(currentCoordinates, newCoords);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        private int[] MoveKingOnBoard(int[] currentCoordinates, int[] newCoords)
        {
            char sign = this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
            this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
            this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;

            for (int i = 0; i < 4; i++)
            {
                this.theKing.FigureExistingMoves[i] = true;
            }

            return newCoords;
        }

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

            //// Test all pawns down
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

        /* PAWN LOGIC */

        public void ProcessPawnSide()
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
                    isExecuted = this.ProcessCommand(input);
                }
            }

            bool hasKingExistingMove = this.HasKingExistingMove(this.theKing.FigurePosition);
            if (hasKingExistingMove == false)
            {
                this.GameIsFinished = true;
                Console.WriteLine("King loses!");
            }

            this.HasPawnsExistingMove();
            this.InteractWithUser();
        }

        private bool MovePawn(string checkedInput)
        {
            char figure = checkedInput[0];
            int[] coords = new int[3];

            for (int i = 0; i < this.allPawns.Count; i++)
            {
                if (this.allPawns[i].FigureSign == figure)
                {
                    coords = this.allPawns[i].GetFigureNewCoords(checkedInput);

                    if (this.CalcNextPawnPosition(coords, this.allPawns[i].FigurePosition, figure) != null)
                    {
                        this.allPawns[i].FigurePosition[0] = coords[0];
                        this.allPawns[i].FigurePosition[1] = coords[1];
                    }
                    else
                    {
                        this.ProcessPawnSide();
                    }

                    break;
                }
            }

            return true;
        }

        private int[] CalcNextPawnPosition(int[] newCoords, int[] currentCoordinates, char currentPawn)
        {
            if (this.kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                this.kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                this.kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        this.firstPawn.FigureExistingMoves[0] = true;
                        this.firstPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'B':
                        this.secondPawn.FigureExistingMoves[0] = true;
                        this.secondPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'C':
                        this.thirdPawn.FigureExistingMoves[0] = true;
                        this.thirdPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'D':
                        this.fourthPawn.FigureExistingMoves[0] = true;
                        this.fourthPawn.FigureExistingMoves[1] = true;
                        break;
                    default:
                        throw new ArgumentException("The currunet pawn type was invalid!");
                        break;
                }

                return newCoords;
            }
            else
            {
                switch (currentPawn)
                {
                    case 'A':
                        this.firstPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'B':
                        this.secondPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'C':
                        this.thirdPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'D':
                        this.fourthPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    default:
                        throw new ArgumentException("The currunet pawn type was invalid!");
                        break;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        private void HasPawnsExistingMove()
        {
            bool allAreFalse = true;
            int[,] displasment = 
            { 
                { 1, -2 },
                { 1, 2 }        
            };

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

            if (allAreFalse)
            {
                Console.WriteLine("King wins!");
                this.GameIsFinished = true;
            }
        }

        public virtual string ReadPawnInput()
        {
            //// Pawns win, king is in down right corner
            ////string[] sampleInput = new string[] {
            ////"cdr",
            ////"cdr",
            ////"cdl",
            ////"cdr",
            ////"cdr",
            ////"cdl"
            ////};

            ////King win
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

            //// Test all pawns down
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
    }
}