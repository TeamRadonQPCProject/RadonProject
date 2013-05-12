namespace KingSurvival
{
    using System;

    public class King : Figure
    {
        private readonly char figureSign = 'K';

        private readonly string[] validFigureInputs = 
        {                               
            "KUL",                                  
            "KUR",       
            "KDL", 
            "KDR" 
        };

        private int[] figurePosition = 
        { 
            9, 
            10 
        };

        private bool[] figureExistingMoves = 
        { 
            true, 
            true, 
            true, 
            true 
        };

        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        public override string[] ValidFigureInputs
        {
            get
            {
                return validFigureInputs;
            }
        }

        public override int[] FigurePosition
        {
            get
            {
                return figurePosition;
            }

            set
            {
                figurePosition = value;
            }
        }

        public override bool[] FigureExistingMoves
        {
            get
            {
                return figureExistingMoves;
            }

            set
            {
                figureExistingMoves = value;
            }
        }

        public override int[] MoveFigure(string command)
        {
            throw new NotImplementedException();
        }


        public void ProcessKingSide(GameBoard currentBoard)
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
                    isExecuted = ProcessKingCommand(input, currentBoard);
                }
            }
        }

        public bool HasKingExistingMove(int[] currentCoords, GameBoard currentBoard)
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
                if (!(currentBoard.CheckPositionInBoard(newCoords) && currentBoard.Board[newCoords[0], newCoords[1]] == ' '))
                {
                    this.FigureExistingMoves[i] = false;
                }
            }

            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (this.FigureExistingMoves[i] == true)
                {
                    allAreFalse = false;
                }
            }

            if (allAreFalse)
            {
                return false;
                //this.GameIsFinished = true;
                //Console.WriteLine("King loses!");
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

        private bool ProcessKingCommand(string checkedInput, GameBoard currentBoard)
        {
            bool isCommandNameCorrect = base.ChechInput(checkedInput, this.ValidFigureInputs);

            if (isCommandNameCorrect)
            {
                if (checkedInput[1] == 'U')
                {
                    if (checkedInput[2] == 'L')
                    {
                        MoveKing('U', 'L', currentBoard);
                    }
                    else
                    {
                        MoveKing('U', 'R', currentBoard);
                    }

                    return true;
                }
                else
                {
                    if (checkedInput[2] == 'L')
                    {
                        MoveKing('D', 'L', currentBoard);
                    }
                    else
                    {
                        MoveKing('D', 'R', currentBoard);
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void MoveKing(char firstDirection, char secondDirection, GameBoard currentBoard)
        {
            int[] oldCoordinates = new int[2];

            oldCoordinates[0] = this.FigurePosition[0];
            oldCoordinates[1] = this.FigurePosition[1];

            int[] newCoords = new int[2];
            newCoords = CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection, currentBoard);

            if (newCoords != null)
            {
                this.FigurePosition[0] = newCoords[0];
                this.FigurePosition[1] = newCoords[1];
            }
            else
            {
                ProcessKingSide(currentBoard);
            }
        }

        private int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection, GameBoard currentBoard)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };

            string direction = firstDirection.ToString() + secondDirection.ToString();
            switch (direction)
            {
                case "UL":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpLeft, currentBoard);
                case "UR":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpRight, currentBoard);
                case "DL":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownLeft, currentBoard);
                case "DR":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownRight, currentBoard);
                default:
                    return null;
            }
        }

        private int[] CheckKingAvailableMove(int[] currentCoordinates, int[] displacementDirection, GameBoard currentBoard)
        {
            int[] newCoords = new int[2];
            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];
            if (currentBoard.CheckPositionInBoard(newCoords) && currentBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                return MoveKingOnBoard(currentCoordinates, newCoords, currentBoard);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        private int[] MoveKingOnBoard(int[] currentCoordinates, int[] newCoords, GameBoard currentBoard)
        {
            char sign = currentBoard.Board[currentCoordinates[0], currentCoordinates[1]];
            currentBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
            currentBoard.Board[newCoords[0], newCoords[1]] = sign;

            for (int i = 0; i < 4; i++)
            {
                this.FigureExistingMoves[i] = true;
            }

            return newCoords;
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

            //string[] sampleInput = new string[] {
            //"kur",
            //"kur",
            //"kur",
            //"kur",
            //"kul",
            //"kul",
            //"kur"
            //};

            // Test all pawns down
            //string[] sampleInput = new string[] {
            //"kur",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kur",
            //"kdl",
            //"kul",
            //"kul",
            //"kul",
            //"kdr",
            //"kul",
            //"kdr",
            //"kul",
            //"kdr",
            //"kul",
            //"kdr",
            //"kul",
            //"kdr",
            //"kul"
            //};

            //if (indexKing < sampleInput.Length)
            //{
            //    //Console.WriteLine(indexKing);
            //    Console.WriteLine(sampleInput[indexKing]);
            //    return sampleInput[indexKing++];
            //}

            string kingInput = Console.ReadLine();
            return kingInput;
        }
    }
}
