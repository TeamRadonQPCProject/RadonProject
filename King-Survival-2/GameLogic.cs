namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    public class GameLogic
    {
        // game objects
        // TODO: Move them to different class
        private GameBoard KingSurvivalGameBoard = new GameBoard();
        private PawnA firstPawn = new PawnA();
        private PawnB secondPawn = new PawnB();
        private PawnC thirdPawn = new PawnC();
        private PawnD fourthPawn = new PawnD();
        private King theKing = new King();
        private List<Figure> allPawns = new List<Figure>();


        // fileds
        private int movementsCounter = 0;
        private bool gameIsFinished = false;

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
        public void Init() 
        {
            allPawns.Add(firstPawn);
            allPawns.Add(secondPawn);
            allPawns.Add(thirdPawn);
            allPawns.Add(fourthPawn);
        }

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
                    KingSurvivalGameBoard.ShowBoard();
                    ProcessKingSide();
                }
                else
                {
                    KingSurvivalGameBoard.ShowBoard();
                    ProcessPawnSide();
                }
            }
        }

        public bool CheckPlayerInput(string checkedString)
        {
            char startLetter = checkedString[0];
            if (this.MovementsCounter % 2 == 0) // King turn
            {
                return this.ChechInput(checkedString, theKing.ValidFigureInputs);
            }
            else // PawnsTurn
            {
                switch (startLetter)
                {
                    case 'A':
                        return ChechInput(checkedString, firstPawn.ValidFigureInputs);

                    case 'B':
                        return ChechInput(checkedString, secondPawn.ValidFigureInputs);

                    case 'C':
                        return ChechInput(checkedString, thirdPawn.ValidFigureInputs);

                    case 'D':
                        return ChechInput(checkedString, fourthPawn.ValidFigureInputs);

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                }
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

            // write on console if There is no Valid input
            if (!hasAnEqual)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command name!");
                Console.ResetColor();
            }

            return hasAnEqual;
        }

        public bool CheckAndProcess(string checkedInput)
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

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                MoveKing('U', 'L');
                            }
                            else
                            {
                                MoveKing('U', 'R');
                            }

                            return true;
                        }
                        else
                        {
                            if (checkedInput[2] == 'L')
                            {
                                MoveKing('D', 'L');
                            }
                            else
                            {
                                MoveKing('D', 'R');
                            }

                            return true;
                        }

                    default:
                        throw new ArgumentException("Input command start was invalid!");
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

            oldCoordinates[0] = theKing.FigurePosition[0];
            oldCoordinates[1] = theKing.FigurePosition[1];

            int[] newCoords = new int[2];
            newCoords = CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection);

            if (newCoords != null)
            {
                theKing.FigurePosition[0] = newCoords[0];
                theKing.FigurePosition[1] = newCoords[1];
            }
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
                    this.CalcNextPawnPosition(coords, allPawns[i].FigurePosition, figure);

                    allPawns[i].FigurePosition[0] = coords[0];
                    allPawns[i].FigurePosition[1] = coords[1];
                }
            }

            if (coords != null)
            {

                if (figure == 'A')
                {
                    firstPawn.FigurePosition[0] = coords[0];
                    firstPawn.FigurePosition[1] = coords[1];
                }
                else if (figure == 'B')
                {
                    secondPawn.FigurePosition[0] = coords[0];
                    secondPawn.FigurePosition[1] = coords[1];
                }
                else if (figure == 'C')
                {
                    thirdPawn.FigurePosition[0] = coords[0];
                    thirdPawn.FigurePosition[1] = coords[1];
                }
                else if (figure == 'D')
                {
                    fourthPawn.FigurePosition[0] = coords[0];
                    fourthPawn.FigurePosition[1] = coords[1];
                }
            }

            return true;
        }

        public void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = ReadKingInput();

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
                    isExecuted = CheckAndProcess(input);
                }
            }

            InteractWithUser();
        }

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
                    isExecuted = CheckAndProcess(input);
                }
            }

            HasKingExistingMove(theKing.FigurePosition);
            InteractWithUser();
        }

        public void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", this.MovementsCounter / 2);
                this.GameIsFinished = true;
            }
        }

        private int[] CalcNextPawnPosition(int[] newCoords, int[] currentCoordinates, char currentPawn)
        {
            if (KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
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
                bool allAreFalse = true;
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

                Figure[] allFigres = { firstPawn, secondPawn, thirdPawn, fourthPawn };

                for (int i = 0; i < allFigres.Length; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (allFigres[i].FigureExistingMoves[j] == true)
                        {
                            allAreFalse = false;
                        }
                    }
                }

                if (allAreFalse)
                {
                    this.GameIsFinished = true;
                    Console.WriteLine("King wins!");
                    this.GameIsFinished = true;
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        public int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };

            string direction = firstDirection.ToString() + secondDirection.ToString();
            switch (direction)
            {
                case "UL":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpLeft);
                case "UR":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpRight);
                case "DL":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownLeft);
                case "DR":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownRight);
                default:
                    return null;
            }
        }

        private int[] CheckKingAvailableMove(int[] currentCoordinates, int[] displacementDirection)
        {
            //HasExistingMove(currentCoordinates);
            int[] newCoords = new int[2];
            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];
            if (KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;

                for (int i = 0; i < 4; i++)
                {
                    theKing.FigureExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return newCoords;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        // TODO: Move to King class
        private void HasKingExistingMove(int[] currentCoords)
        {
            int[] newCoords = new int[2];
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };

            newCoords[0] = currentCoords[0] + displacementUpLeft[0];
            newCoords[1] = currentCoords[1] + displacementUpLeft[1];
            if (!(KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
            {
                theKing.FigureExistingMoves[0] = false;
            }

            newCoords[0] = currentCoords[0] + displacementUpRight[0];
            newCoords[1] = currentCoords[1] + displacementUpRight[1];
            if (!(KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
            {
                theKing.FigureExistingMoves[1] = false;
            }

            newCoords[0] = currentCoords[0] + displacementDownLeft[0];
            newCoords[1] = currentCoords[1] + displacementDownLeft[1];
            if (!(KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
            {
                theKing.FigureExistingMoves[2] = false;
            }

            newCoords[0] = currentCoords[0] + displacementDownRight[0];
            newCoords[1] = currentCoords[1] + displacementDownRight[1];
            if (!(KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' '))
            {
                theKing.FigureExistingMoves[3] = false;
            }

            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (theKing.FigureExistingMoves[i] == true)
                {
                    allAreFalse = false;
                }
            }

            if (allAreFalse)
            {
                this.GameIsFinished = true;
                Console.WriteLine("King loses!");
            }
        }

        private int indexKing = 0;
        public virtual string ReadKingInput()
        {
            //string[] sampleInput = new string[] {
            //"kur",
            //"kur",
            //"kul",
            //"kdr",
            //"kdr",
            //"kdr"
            //};

            //return sampleInput[indexKing++];
            string kingInput = Console.ReadLine();
            return kingInput;
        }

        private int indexPawn = 0;
        public virtual string ReadPawnInput()
        {
            //string[] sampleInput = new string[] {
            //"cdr",
            //"cdr",
            //"cdl",
            //"cdr",
            //"cdr",
            //"cdl"
            //};

            //return sampleInput[indexPawn++];
            string pawnInput = Console.ReadLine();
            return pawnInput;
        }
    }
}