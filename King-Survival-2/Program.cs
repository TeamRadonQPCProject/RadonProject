namespace KingSurvivalGame
{
    using System;

    class KingSurvivalGame
    {
        static char[,] board = 
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

        static int[,] boardCorners = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }
        };

        static int[] kingPosition = { 9, 10 };

        static int[,] pawnsPosition = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };

        static bool[] kingExistingMoves = { true, true, true, true };

        static bool[,] pawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        static string[] validKingInputs = { "KUL", "KUR", "KDL", "KDR" };

        static string[] validAPawnInputs = { "ADL", "ADR" };

        static string[] validBPawnInputs = { "BDL", "BDR" };

        static string[] validCPawnInputs = { "CDL", "CDR" };

        static string[] validDPawnInputs = { "DDL", "DDR" };

        static int movementsCounter = 0;

        static bool gameIsFinished = false;

        static bool CheckPositionInBoard(int[] positionCoodinates)
        {
            int positonRow = positionCoodinates[0];
            bool isRowInBoard = (positonRow >= boardCorners[0, 0]) && (positonRow <= boardCorners[3, 0]);
            int positonCol = positionCoodinates[1];
            bool isColInBoard = (positonCol >= boardCorners[0, 1]) && (positonCol <= boardCorners[3, 1]);
            return isRowInBoard && isColInBoard;
        }

        static void ShowBoard()
        {
            // After every figure move clear console
            Console.Clear();

            // This will print empty line on console
            Console.WriteLine();

            // Make board colorful
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = CheckPositionInBoard(coordinates);
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
                                Console.Write(board[row, col]);
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
                            Console.Write(board[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(board[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }
  
        private static void PrintBlueSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(board[row, col]);
            Console.ResetColor();
        }
  
        private static void PrintGreenSquareWithBlackFont(int row, int col)
        {
            // Set colors on console
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            // Print element to board
            Console.Write(board[row, col]);
            Console.ResetColor();
        }

        static void InteractWithUser(int moveCounter)
        {
            if (gameIsFinished)
            {
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    ShowBoard();
                    ProcessKingSide();
                }
                else
                {
                    ShowBoard();
                    ProcessPawnSide();
                }
            }
        }

        static bool CheckPlayerInput(string checkedString)
        {
            char startLetter = checkedString[0];
            bool hasAnEqual = false;
            if (movementsCounter % 2 == 0) // King turn
            {
                return ChechInput(checkedString, validKingInputs, ref hasAnEqual);
            }
            else // PawnsTurn
            {
                switch (startLetter)
                {
                    case 'A':
                        return ChechInput(checkedString, validAPawnInputs, ref hasAnEqual);

                    case 'B':
                        return ChechInput(checkedString, validBPawnInputs, ref hasAnEqual);

                    case 'C':
                        return ChechInput(checkedString, validCPawnInputs, ref hasAnEqual);

                    case 'D':
                        return ChechInput(checkedString, validDPawnInputs, ref hasAnEqual);

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
            oldCoordinates[0] = kingPosition[0];
            oldCoordinates[1] = kingPosition[1];
            int[] coords = new int[2];
            coords = CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection);
            if (coords != null)
            {
                kingPosition[0] = coords[0];
                kingPosition[1] = coords[1];
            }
        }
  
        private static bool MovePawn(string checkedInput, char figure)
        {
            int pawnsPositionFirstCoord = (int)figure - (int)'A';
            if (checkedInput[2] == 'L')
            {
                int[] oldCoordinates = new int[2];
                oldCoordinates[0] = pawnsPosition[pawnsPositionFirstCoord, 0];
                oldCoordinates[1] = pawnsPosition[pawnsPositionFirstCoord, 1];

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'L', figure);
                if (coords != null)
                {
                    pawnsPosition[pawnsPositionFirstCoord, 0] = coords[0];
                    pawnsPosition[pawnsPositionFirstCoord, 1] = coords[1];
                }
            }
            else
            {
                // =='R'
                int[] oldCoordinates = new int[2];
                oldCoordinates[0] = pawnsPosition[pawnsPositionFirstCoord, 0];
                oldCoordinates[1] = pawnsPosition[pawnsPositionFirstCoord, 1];

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'R', figure);
                if (coords != null)
                {
                    pawnsPosition[pawnsPositionFirstCoord, 0] = coords[0];
                    pawnsPosition[pawnsPositionFirstCoord, 1] = coords[1];
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
                    input = input.ToUpper(); // ! input =
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

            InteractWithUser(movementsCounter);
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

                // input = input.Trim();
                if (input != null) //"/n")
                {
                    // Console.WriteLine(input);
                    // Console.WriteLine("hahah");
                    input = input.ToUpper(); //! input =
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

            InteractWithUser(movementsCounter);
        }

        static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", movementsCounter / 2);
                gameIsFinished = true;
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
            if (CheckPositionInBoard(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = board[currentCoordinates[0], currentCoordinates[1]];
                board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                board[newCoords[0], newCoords[1]] = sign;
                movementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        pawnExistingMoves[0, 0] = true;
                        pawnExistingMoves[0, 1] = true;
                        break;
                    case 'B':
                        pawnExistingMoves[1, 0] = true;
                        pawnExistingMoves[1, 1] = true;
                        break;
                    case 'C':
                        pawnExistingMoves[2, 0] = true;
                        pawnExistingMoves[2, 1] = true;
                        break;
                    case 'D':
                        pawnExistingMoves[3, 0] = true;
                        pawnExistingMoves[3, 1] = true;
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
                        pawnExistingMoves[0, pawnSecondCoord] = false;
                        break;
                    case 'B':
                        pawnExistingMoves[1, pawnSecondCoord] = false;
                        break;
                    case 'C':
                        pawnExistingMoves[2, pawnSecondCoord] = false;
                        break;
                    case 'D':
                        pawnExistingMoves[3, pawnSecondCoord] = false;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (pawnExistingMoves[i, j] == true)
                        {
                            allAreFalse = false;
                        }
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King wins!");
                    gameIsFinished = true;
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
            if (CheckPositionInBoard(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = board[currentCoordinates[0], currentCoordinates[1]];
                board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                board[newCoords[0], newCoords[1]] = sign;
                movementsCounter++;

                for (int i = 0; i < 4; i++)
                {
                    kingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return newCoords;
            }
            else
            {
                kingExistingMoves[0] = false;
                bool allAreFalse = true;
                for (int i = 0; i < 4; i++)
                {
                    if (kingExistingMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King loses!");
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        static void Main()
        {
            InteractWithUser(movementsCounter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}