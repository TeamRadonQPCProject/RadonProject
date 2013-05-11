namespace KingSurvival
{
    using System;

    public class PawnB : Pawn
    {
        // fields
        private char figureSign = 'B';

        private readonly string[] validFigureInputs = 
        { 
            "BDL", 
            "BDR" 
        };

        private int[] figurePosition = 
        {
             2, 8 
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
    }
}
