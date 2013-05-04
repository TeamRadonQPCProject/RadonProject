namespace KingSurvival
{
    using System;

    public class GameLogic
    {
        // fileds
        private static int movementsCounter = 0;
        private static bool gameIsFinished = false;
        
        // properties
        public static bool GameIsFinished
        {
            get
            {
                return gameIsFinished;
            }

            set
            {
                gameIsFinished = value;
            }
        }

        public static int MovementsCounter
        {
            get
            {
                return movementsCounter;
            }

            set
            {
                movementsCounter = value;
            }
        }

        // methods
        public static void InteractWithUser(int moveCounter)
        {
            if (GameLogic.GameIsFinished)
            {
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    GameBoard.ShowBoard();
                    ProcessKingSide();
                }
                else
                {
                    GameBoard.ShowBoard();
                    ProcessPawnSide();
                }
            }
        }

        static bool CheckPlayerInput(string checkedString)
        {
            char startLetter = checkedString[0];
            bool hasAnEqual = false;
            if (GameLogic.MovementsCounter % 2 == 0) // King turn
            {
                return ChechInput(checkedString, King.ValidKingInputs, ref hasAnEqual);
            }
            else // PawnsTurn
            {
                switch (startLetter)
                {
                    case 'A':
                        return ChechInput(checkedString, PawnA.ValidAPawnInputs, ref hasAnEqual);

                    case 'B':
                        return ChechInput(checkedString, PawnB.validBPawnInputs, ref hasAnEqual);

                    case 'C':
                        return ChechInput(checkedString, PawnC.ValidCPawnInputs, ref hasAnEqual);

                    case 'D':
                        return ChechInput(checkedString, PawnD.ValidDPawnInputs, ref hasAnEqual);

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                }
            }
        }

        private static bool ChechInput(string checkedString, string[] currentFigureValidInput, ref bool hasAnEqual)
        {
            int[] equal = new int[currentFigureValidInput.Length];
            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                string reference = currentFigureValidInput[i];
                int result = checkedString.CompareTo(reference);
                if (result != 0)
                {
                    equal[i] = 0;
                }
                else
                {
                    equal[i] = 1;
                }
            }

            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                if (equal[i] == 1)
                {
                    hasAnEqual = true;
                }
            }

            if (!hasAnEqual)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command name!");
                Console.ResetColor();
            }

            return hasAnEqual;
        }

        static bool CheckAndProcess(string checkedInput)
        {
            bool isCommandNameCorrect = CheckPlayerInput(checkedInput);
            if (isCommandNameCorrect)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        return MovePawn(checkedInput, 'A');

                    case 'B':
                        return MovePawn(checkedInput, 'B');

                    case 'C':
                        return MovePawn(checkedInput, 'C');

                    case 'D':
                        return MovePawn(checkedInput, 'D');

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
                        Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!");
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void MoveKing(char firstDirection, char secondDirection)
        {
            // ==KDR
            int[] oldCoordinates = new int[2];
            oldCoordinates[0] = King.KingPosition[0];
            oldCoordinates[1] = King.KingPosition[1];
            int[] coords = new int[2];
            coords = CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection);
            if (coords != null)
            {
                King.KingPosition[0] = coords[0];
                King.KingPosition[1] = coords[1];
            }
        }

        private static bool MovePawn(string checkedInput, char figure)
        {
            int pawnsPositionFirstCoord = (int)figure - (int)'A';
            if (checkedInput[2] == 'L')
            {
                int[] oldCoordinates = new int[2];
                oldCoordinates[0] = Pawn.PawnsPosition[pawnsPositionFirstCoord, 0];
                oldCoordinates[1] = Pawn.PawnsPosition[pawnsPositionFirstCoord, 1];

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'L', figure);
                if (coords != null)
                {
                    Pawn.PawnsPosition[pawnsPositionFirstCoord, 0] = coords[0];
                    Pawn.PawnsPosition[pawnsPositionFirstCoord, 1] = coords[1];
                }
            }
            else
            {
                // =='R'
                int[] oldCoordinates = new int[2];
                oldCoordinates[0] = Pawn.PawnsPosition[pawnsPositionFirstCoord, 0];
                oldCoordinates[1] = Pawn.PawnsPosition[pawnsPositionFirstCoord, 1];

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'R', figure);
                if (coords != null)
                {
                    Pawn.PawnsPosition[pawnsPositionFirstCoord, 0] = coords[0];
                    Pawn.PawnsPosition[pawnsPositionFirstCoord, 1] = coords[1];
                }
            }

            return true;
        }

        static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndProcess(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(GameLogic.MovementsCounter);
        }

        static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (input != null)
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndProcess(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(GameLogic.MovementsCounter);
        }

        static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", GameLogic.MovementsCounter / 2);
                GameLogic.GameIsFinished = true;
            }
        }

        static int[] CheckNextPownPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];

                return CalcNextPawnPosition(newCoords, currentCoordinates, currentPawn, 0);
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];

                return CalcNextPawnPosition(newCoords, currentCoordinates, currentPawn, 1);
            }
        }

        private static int[] CalcNextPawnPosition(int[] newCoords, int[] currentCoordinates, char currentPawn, int pawnSecondCoord)
        {
            if (GameBoard.CheckPositionInBoard(newCoords) && GameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = GameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                GameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                GameBoard.Board[newCoords[0], newCoords[1]] = sign;
                GameLogic.MovementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        Pawn.PawnExistingMoves[0, 0] = true;
                        Pawn.PawnExistingMoves[0, 1] = true;
                        break;
                    case 'B':
                        Pawn.PawnExistingMoves[1, 0] = true;
                        Pawn.PawnExistingMoves[1, 1] = true;
                        break;
                    case 'C':
                        Pawn.PawnExistingMoves[2, 0] = true;
                        Pawn.PawnExistingMoves[2, 1] = true;
                        break;
                    case 'D':
                        Pawn.PawnExistingMoves[3, 0] = true;
                        Pawn.PawnExistingMoves[3, 1] = true;
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
                        Pawn.PawnExistingMoves[0, pawnSecondCoord] = false;
                        break;
                    case 'B':
                        Pawn.PawnExistingMoves[1, pawnSecondCoord] = false;
                        break;
                    case 'C':
                        Pawn.PawnExistingMoves[2, pawnSecondCoord] = false;
                        break;
                    case 'D':
                        Pawn.PawnExistingMoves[3, pawnSecondCoord] = false;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (Pawn.PawnExistingMoves[i, j] == true)
                        {
                            allAreFalse = false;
                        }
                    }
                }

                if (allAreFalse)
                {
                    GameLogic.GameIsFinished = true;
                    Console.WriteLine("King wins!");
                    GameLogic.GameIsFinished = true;
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
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

        private static int[] CheckKingAvailableMove(int[] currentCoordinates, int[] displacementDirection)
        {
            int[] newCoords = new int[2];
            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];
            if (GameBoard.CheckPositionInBoard(newCoords) && GameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = GameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                GameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                GameBoard.Board[newCoords[0], newCoords[1]] = sign;
                GameLogic.MovementsCounter++;

                for (int i = 0; i < 4; i++)
                {
                    King.KingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return newCoords;
            }
            else
            {
                King.KingExistingMoves[0] = false;
                bool allAreFalse = true;
                for (int i = 0; i < 4; i++)
                {
                    if (King.KingExistingMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    GameLogic.GameIsFinished = true;
                    Console.WriteLine("King loses!");
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }
    }
}