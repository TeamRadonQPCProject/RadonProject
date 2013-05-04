namespace KingSurvival
{
    using System;

    public class PawnA : Pawn
    {
        private static readonly string[] validAPawnInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        public static string[] ValidAPawnInputs
        {
            get
            {
                return validAPawnInputs;
            }
        }
    }
}
