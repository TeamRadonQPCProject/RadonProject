namespace KingSurvival
{
    class GameBoard
    {
        private char[,] board;
        private int[,] boardCorners;

        public char[,] Board
        {
            get { return this.board; }
            set { this.board = value; }
        }

        public int[,] BoardCorners
        {
            get { return this.boardCorners; }
            set { this.boardCorners = value; }
        }
    }
}
