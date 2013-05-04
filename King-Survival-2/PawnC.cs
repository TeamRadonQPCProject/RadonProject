namespace KingSurvival
{
    using System;

    public class PawnC : Pawn
    {
        private string[] validCPawnInputs = 
        {
            "CDL",
            "CDR"
        };

        public string[] ValidCPawnInputs
        {
            get
            {
                return this.validCPawnInputs;
            }
        }
    }
}
