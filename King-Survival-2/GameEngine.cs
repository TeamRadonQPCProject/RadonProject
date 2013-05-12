namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

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
        private readonly List<Figure> allPawns = new List<Figure>();

        // properties
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

        public int MovementsCounter
        {
            get
            {
                return this.movementsCounter;
            }

            set
            {
                this.movementsCounter = value;
            }
        }

        // methods

        /* COMMAND PROCESS */
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
                    int currentKingXAxe = theKing.FigurePosition[0];
                    bool isKingExit = theKing.CheckForKingExit(currentKingXAxe);
                    if (isKingExit)
                    {
                        Console.WriteLine("End!");
                        Console.WriteLine("King wins in {0} moves!", this.MovementsCounter / 2);
                        this.GameIsFinished = true;
                    }

                    if (GameIsFinished != true)
                    {
                        this.ShowCurrentBoard();
                        theKing.ProcessKingSide(kingSurvivalGameBoard);
                        this.MovementsCounter++;
                        InteractWithUser();
                    }
                }
                else
                {
                    this.ShowCurrentBoard();
                    this.ProcessPawnSide();
                }
            }
        }

        public void StartGame()
        {
            firstPawn = new PawnA();
            secondPawn = new PawnB();
            thirdPawn = new PawnC();
            fourthPawn = new PawnD();
            kingSurvivalGameBoard = new GameBoard();
            theKing = new King();

            allPawns.Add(firstPawn);
            allPawns.Add(secondPawn);
            allPawns.Add(thirdPawn);
            allPawns.Add(fourthPawn);
        }

        public void ShowCurrentBoard()
        {
            kingSurvivalGameBoard.ShowBoard();
        }

        public bool CheckPlayerInput(string stringToCheck)
        {
            char startLetter = stringToCheck[0];
            switch (startLetter)
            {
                case 'A':
                    return ChechInput(stringToCheck, firstPawn.ValidFigureInputs);

                case 'B':
                    return ChechInput(stringToCheck, secondPawn.ValidFigureInputs);

                case 'C':
                    return ChechInput(stringToCheck, thirdPawn.ValidFigureInputs);

                case 'D':
                    return ChechInput(stringToCheck, fourthPawn.ValidFigureInputs);

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
            bool isCommandNameCorrect = CheckPlayerInput(checkedInput);

            if (isCommandNameCorrect)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        return MovePawn(checkedInput);

                    case 'B':
                        return MovePawn(checkedInput);

                    case 'C':
                        return MovePawn(checkedInput);

                    case 'D':
                        return MovePawn(checkedInput);

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

        /* PAWN LOGIC */

        public void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = ReadPawnInput();

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
                    isExecuted = ProcessCommand(input);
                }
            }

            bool hasKingExistingMove = theKing.HasKingExistingMove(theKing.FigurePosition, kingSurvivalGameBoard);
            if (hasKingExistingMove == false)
            {
                this.GameIsFinished = true;
                Console.WriteLine("King loses!");
            }

            HasPawnExistingMove();
            InteractWithUser();
        }

        private bool MovePawn(string checkedInput)
        {
            char figure = checkedInput[0];
            int[] coords = new int[3];

            for (int i = 0; i < allPawns.Count; i++)
            {
                if (allPawns[i].FigureSign == figure)
                {
                    coords = allPawns[i].MoveFigure(checkedInput);

                    if (this.CalcNextPawnPosition(coords, allPawns[i].FigurePosition, figure) != null)
                    {
                        allPawns[i].FigurePosition[0] = coords[0];
                        allPawns[i].FigurePosition[1] = coords[1];
                    }

                    break;
                }
            }

            return true;
        }

        private int[] CalcNextPawnPosition(int[] newCoords, int[] currentCoordinates, char currentPawn)
        {
            if (kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                kingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        firstPawn.FigureExistingMoves[0] = true;
                        firstPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'B':
                        secondPawn.FigureExistingMoves[0] = true;
                        secondPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'C':
                        thirdPawn.FigureExistingMoves[0] = true;
                        thirdPawn.FigureExistingMoves[1] = true;
                        break;
                    case 'D':
                        fourthPawn.FigureExistingMoves[0] = true;
                        fourthPawn.FigureExistingMoves[1] = true;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                return newCoords;
            }
            else
            {
                switch (currentPawn)
                {
                    case 'A':
                        firstPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'B':
                        secondPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'C':
                        thirdPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    case 'D':
                        fourthPawn.FigureExistingMoves[newCoords[2]] = false;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }
  
        private void HasPawnExistingMove()
        {
            bool allAreFalse = true;
            Figure[] allFigres = { firstPawn, secondPawn, thirdPawn, fourthPawn };
            int[,] displasment = { {1, -2},
                                 {1, 2} };
            int[] newCoords = new int[2];
            for (int i = 0; i < allFigres.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    newCoords[0] = allFigres[i].FigurePosition[0] + displasment[j, 0];
                    newCoords[1] = allFigres[i].FigurePosition[1] + displasment[j, 1];
                    if (!(kingSurvivalGameBoard.CheckPositionInBoard(newCoords) && kingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
                    {
                        allFigres[i].FigureExistingMoves[j] = false;
                    }
                }
            }

            for (int i = 0; i < allFigres.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (allFigres[i].FigureExistingMoves[j] == true)
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

        private int indexPawn = 0;
        public virtual string ReadPawnInput()
        {
            // Pawns win, king is in down right corner
            //string[] sampleInput = new string[] {
            //"cdr",
            //"cdr",
            //"cdl",
            //"cdr",
            //"cdr",
            //"cdl"
            //};

            //King win
            //string[] sampleInput = new string[]
            //{
            //    "ddl",
            //    "ddl",
            //    "ddl",
            //    "ddl",
            //    "ddl",
            //    "ddl",
            //    "ddr"
            //};

            // Test all pawns down
            //string[] sampleInput = new string[] {
            //"adr",
            //"adl",
            //"adr",
            //"adl",
            //"adr",
            //"adl",
            //"adr",
            //"bdr",
            //"bdl",
            //"bdr",
            //"bdl",
            //"bdr",
            //"bdl",
            //"bdr",
            //"cdr",
            //"cdl",
            //"cdr",
            //"cdl",
            //"cdr",
            //"cdl",
            //"cdr",
            //"ddr",
            //"ddl",
            //"ddr",
            //"ddl",
            //"ddr",
            //"ddl",
            //"ddr",
            //};

            //if (indexPawn < sampleInput.Length)
            //{
            //    //Console.WriteLine(indexPawn);
            //    Console.WriteLine(sampleInput[indexPawn]);
            //    return sampleInput[indexPawn++];
            //}

            string pawnInput = Console.ReadLine();
            return pawnInput;
        }
    }
}