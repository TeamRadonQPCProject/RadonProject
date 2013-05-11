namespace KingSurvival
{
    using System;

    public class PawnA : Figure
    {
        // fields
        private char figureSign = 'A';

        private readonly string[] validFigureInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        private static int[,] figurePosition = 
        {
            { 2, 4 }
        };

        private static bool[,] figureExistingMoves = 
        {
            { true, true }
        };

        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        // properties
        public override int[,] FigurePosition
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

        public override bool[,] FigureExistingMoves
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

        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }

        // methods
        public override bool MoveFigure(string command)
        {
            throw new NotImplementedException();
        }
    }
}
