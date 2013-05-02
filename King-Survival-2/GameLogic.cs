namespace KingSurvival
{
    class GameLogic
    {
        private bool gameIsFinished;
        private int movementCounter;

        public bool GameIsFinished
        {
            get { return this.gameIsFinished; }
            set { this.gameIsFinished = value; }
        }

        public int MovementCounter
        {
            get { return this.movementCounter; }
            set { this.movementCounter = value; }
        }
    }
}