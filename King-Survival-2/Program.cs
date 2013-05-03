namespace KingSurvivalGame
{
    using System;
    using KingSurvival;

    class KingSurvivalGame
    {
        static void Main()
        {
            GameLogic.InteractWithUser(GameLogic.MovementsCounter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}