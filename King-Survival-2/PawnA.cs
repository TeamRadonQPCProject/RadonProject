namespace KingSurvival
{
    using System;

    public class PawnA : Pawn
    {
        // fields
        private readonly char figureSign = 'A';

        private readonly string[] validFigureInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        private static int[] figurePosition = 
        {
             2, 4 
        };

        private static bool[] figureExistingMoves = 
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

        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }
    }
}
