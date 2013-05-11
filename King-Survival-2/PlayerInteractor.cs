namespace KingSurvival
{
    using System;

    public class PlayerInteractor
    {
        private GameEngine myTestEngine = new GameEngine();

        public void StartGame()
        {
            myTestEngine.StartGame();
            myTestEngine.InteractWithUser();
        }
    }
}
