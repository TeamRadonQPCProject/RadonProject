namespace KingSurvival
{
    using System;

    class Pawn : Figure
    {
        private bool[] pawnExistingMoves;
        private int[] pawnPosition;
        private string[] validPawnInputs;

        public string[] ValidPawnInputs
        {
            get { return this.validPawnInputs; }
            set { this.validPawnInputs = value; }
        }

        public bool[] PawnExistingMoves
        {
            get { return this.pawnExistingMoves; }
            set { this.pawnExistingMoves = value; }
        }

        public int[] PawnPosition
        {
            get { return this.pawnPosition; }
            set { this.pawnPosition = value; }
        }
    }
}
