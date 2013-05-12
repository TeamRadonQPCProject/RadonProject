namespace KingSurvival
{
    using System;

    public abstract class Figure
    {
        // fileds
        public virtual char FigureSign { get; private set; }

        public virtual int[] FigurePosition { get; set; }

        public virtual string[] ValidFigureInputs { get; private set; }

        public virtual bool[] FigureExistingMoves { get; set; }

        public abstract int[] MoveFigure(string command);

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
    }
}
