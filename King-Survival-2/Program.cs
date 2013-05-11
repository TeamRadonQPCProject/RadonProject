namespace KingSurvivalGame
{
    using System;
    using KingSurvival;

    class KingSurvivalGame
    {
        static void Main()
        {
            PlayerInteractor myGame = new PlayerInteractor();
            myGame.StartGame();
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}