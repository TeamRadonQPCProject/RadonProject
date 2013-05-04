namespace KingSurvival
{
    using System;

    public class PawnD : Pawn
    {
        private static string[] validDPawnInputs = 
        { 
            "DDL", 
            "DDR" 
        };

        public static string[] ValidDPawnInputs
        {
            get
            {
                return validDPawnInputs;
            }
        }
    }
}
