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
            Console.WriteLine("{0}Thank you for using this game!{0}{0}", Environment.NewLine);
        }
    }
}