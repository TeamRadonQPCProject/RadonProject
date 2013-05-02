﻿namespace KingSurvivalGame
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
                                // Set colors on console
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;

                                // Print element to board
                                Console.Write(board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;

                                Console.Write(board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(board[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.Write(board[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.Write(board[row, col]);
                            Console.ResetColor();
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
            if (movementsCounter % 2 == 0)
            {
                int[] equal = new int[4];
                for (int i = 0; i < validKingInputs.Length; i++)
                {
                    string reference = validKingInputs[i];
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

                bool hasAnEqual = false;
                for (int i = 0; i < 4; i++)
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
            else
            {
                char startLetter = checkedString[0];
                int[] equal = new int[2];
                bool hasAnEqual = false;
                switch (startLetter)
                {
                    case 'A':
                        for (int i = 0; i < validAPawnInputs.Length; i++)
                        {
                            string reference = validAPawnInputs[i];
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

                        for (int i = 0; i < 2; i++)
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

                    case 'B':
                        for (int i = 0; i < validBPawnInputs.Length; i++)
                        {
                            string reference = validBPawnInputs[i];
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

                        for (int i = 0; i < 2; i++)
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

                    case 'C':
                        for (int i = 0; i < validCPawnInputs.Length; i++)
                        {
                            string reference = validCPawnInputs[i];
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

                        for (int i = 0; i < 2; i++)
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

                    case 'D':
                        for (int i = 0; i < validDPawnInputs.Length; i++)
                        {
                            string reference = validDPawnInputs[i];
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

                        for (int i = 0; i < 2; i++)
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

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                }
            }

            return true;
        }

        static bool CheckAndProcess(string checkedInput)
        {
            bool commandNameIsOK = CheckPlayerInput(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':

                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[0, 0];

                            oldCoordinates[1] = pawnsPosition[0, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords != null)
                            {
                                pawnsPosition[0, 0] = coords[0];
                                pawnsPosition[0, 1] = coords[1];
                            }
                        }
                        else
                        {
                            // =='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[0, 0];

                            oldCoordinates[1] = pawnsPosition[0, 1];
                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords != null)
                            {
                                pawnsPosition[0, 0] = coords[0];

                                pawnsPosition[0, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[1, 0];
                            oldCoordinates[1] = pawnsPosition[1, 1];

                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');
                            if (coords != null)
                            {
                                pawnsPosition[1, 0] = coords[0];

                                pawnsPosition[1, 1] = coords[1];
                            }
                        }
                        else
                        {
                            // =='D'
                            int[] oldCoordinates = new int[2];

                            oldCoordinates[0] = pawnsPosition[1, 0];

                            oldCoordinates[1] = pawnsPosition[1, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');
                            if (coords != null)
                            {
                                pawnsPosition[1, 0] = coords[0];

                                pawnsPosition[1, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[2, 0];

                            oldCoordinates[1] = pawnsPosition[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords != null)
                            {
                                pawnsPosition[2, 0] = coords[0];
                                pawnsPosition[2, 1] = coords[1];
                            }
                        }
                        else
                        {
                            // =='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[2, 0];
                            oldCoordinates[1] = pawnsPosition[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords != null)
                            {
                                pawnsPosition[1, 0] = coords[0];
                                pawnsPosition[1, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[3, 0];
                            oldCoordinates[1] = pawnsPosition[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');
                            if (coords != null)
                            {
                                pawnsPosition[3, 0] = coords[0];
                                pawnsPosition[3, 1] = coords[1];
                            }
                        }
                        else
                        {
                            // =='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnsPosition[3, 0];
                            oldCoordinates[1] = pawnsPosition[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords != null)
                            {
                                pawnsPosition[3, 0] = coords[0];
                                pawnsPosition[3, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'L');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'R');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }

                            return true;
                        }
                        else
                        {
                            // =KD_
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'L');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }
                            else
                            {
                                // ==KDD
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'R');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
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
                return false; // message is from other
            }
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
                    /* switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 0] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 0] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 0] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 0] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0,i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;

                        case 'B':
                            pawnExistingMoves[1, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;

                        case 'C':
                            pawnExistingMoves[2, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;

                        case 'D':
                            pawnExistingMoves[3, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
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
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
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
                    /*   switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 1] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 1] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 1] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 1] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'B':
                            pawnExistingMoves[1, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'D':
                            pawnExistingMoves[3, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
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
        }

        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            int[] newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
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
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];

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
                        kingExistingMoves[1] = false;
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
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
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
                        kingExistingMoves[2] = false;
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
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
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
                        kingExistingMoves[3] = false;
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

                // checkForKingExit();
            }
        }

        static void Main()
        {
            InteractWithUser(movementsCounter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}