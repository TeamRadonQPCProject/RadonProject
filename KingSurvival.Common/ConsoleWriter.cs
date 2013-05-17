//-----------------------------------------------------------------------
// <copyright file="ConsoleWriter.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A helper static class for console writing.
    /// </summary>
    public static class ConsoleWriter
    {
        /// <summary>
        /// Writing a invalid command message.
        /// </summary>
        public static void WriteInvalidCommand()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid command name!");
            Console.ResetColor();
        }

        /// <summary>
        /// Writing a wrong direction message.
        /// </summary>
        public static void WriteWrongDirection()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You can't go in this direction! ");
            Console.ResetColor();
        }
    }
}
