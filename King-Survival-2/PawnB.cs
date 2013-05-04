namespace KingSurvival
{
    using System;

    public class PawnB : Pawn
    {
        public static readonly string[] validBPawnInputs = 
        { 
            "BDL", 
            "BDR" 
        };

        public static string[] ValidBPawnInputs
        {
            get
            {
                return validBPawnInputs;
            }
        }
    }
}
