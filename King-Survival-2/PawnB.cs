namespace KingSurvival
{
    using System;

    public class PawnB : Pawn
    {
        public readonly string[] validBPawnInputs = 
        { 
            "BDL", 
            "BDR" 
        };

        public string[] ValidBPawnInputs
        {
            get
            {
                return this.validBPawnInputs;
            }
        }
    }
}
