namespace KingSurvival
{
    using System;

    public static class ConsoleWriter
    {
        public static void WriteInvalidCommand()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid command name!");
            Console.ResetColor();
        }

        public static void WriteWrongDirection()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You can't go in this direction! ");
            Console.ResetColor();
        }
    }
}
