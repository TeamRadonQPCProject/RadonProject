namespace KingSurvival
{
    using System;

    public class PawnC : Figure
    {
        private char figureSign = 'C';

        private string[] validFigureInputs = 
        {
            "CDL",
            "CDR"
        };

        private int[] figurePosition = 
        {
            2, 12
        };

        private bool[] figureExistingMoves = 
        {
            true, true
        };

        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        // properties
        public override int[] FigurePosition
        {
            get
            {
                return this.figurePosition;
            }
            set
            {
                this.figurePosition = value;
            }
        }

        public override bool[] FigureExistingMoves
        {
            get
            {
                return this.figureExistingMoves;
            }
            set
            {
                this.figureExistingMoves = value;
            }
        }

        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }

        // methods
        public override int[] MoveFigure(string command)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };

            int[] oldCoordinates = new int[2];

            oldCoordinates[0] = this.FigurePosition[0];
            oldCoordinates[1] = this.FigurePosition[1];

            int[] newCoords = new int[3];

            if (command[2] == 'L')
            {
                newCoords[0] = oldCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = oldCoordinates[1] + displasmentDownLeft[1];
                newCoords[2] = 0;
                return newCoords;
            }
            else if (command[2] == 'R')
            {
                newCoords[0] = oldCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = oldCoordinates[1] + displasmentDownRight[1];
                newCoords[2] = 1;
                return newCoords;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Moveing command was invalid");
            }
        }
    }
}
