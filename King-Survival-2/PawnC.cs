namespace KingSurvival
{
    using System;

    public class PawnC : Pawn
    {
        private static string[] validCPawnInputs = 
        {
            "CDL",
            "CDR"
        };

        public static string[] ValidCPawnInputs
        {
            get
            {
                return validCPawnInputs;
            }
        }
    }
}
