namespace KingSurvivalGameTest
{
    using System;
    using KingSurvival;

    public class KingSurvivalGame
    {
        public static void Main()
        {
            PlayerInteractor myGame = new PlayerInteractor();
            myGame.StartGame();
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}