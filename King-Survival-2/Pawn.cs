namespace KingSurvival
{
    using System;

    public class Pawn : Figure
    {
        public static int[,] pawnsPosition = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };

        public static bool[,] pawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        private string[] validPawnInputs;

        public string[] ValidPawnInputs
        {
            get { return this.validPawnInputs; }
            set { this.validPawnInputs = value; }
        }
    }
}
