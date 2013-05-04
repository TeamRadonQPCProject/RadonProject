namespace KingSurvival
{
    using System;

    public abstract class Pawn : Figure
    {
        // fileds
        private static int[,] pawnsPosition = 
        {
            { 2, 4 }, 
            { 2, 8 }, 
            { 2, 12 }, 
            { 2, 16 }
        };

        private static bool[,] pawnExistingMoves = 
        {
            { true, true }, 
            { true, true }, 
            { true, true }, 
            { true, true }
        };

        private string[] validPawnInputs;

        // properties
        public static int[,] PawnsPosition
        {
            get
            {
                return pawnsPosition;
            }

            set
            {
                pawnsPosition = value;
            }
        }

        public static bool[,] PawnExistingMoves
        {
            get
            {
                return pawnExistingMoves;
            }

            set
            {
                pawnExistingMoves = value;
            }
        }

        public string[] ValidPawnInputs
        {
            get 
            { 
                return this.validPawnInputs; 
            }

            set 
            { 
                this.validPawnInputs = value; 
            }
        }
    }
}
