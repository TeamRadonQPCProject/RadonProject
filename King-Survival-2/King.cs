namespace KingSurvival
{
    using System;

    public class King : Figure
    {
        public static string[] validKingInputs = { "KUL", "KUR", "KDL", "KDR" };
        public static int[] kingPosition = { 9, 10 };
        public static bool[] kingExistingMoves = { true, true, true, true };
    }
}
