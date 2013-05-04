namespace KingSurvival
{
    using System;

    public class PawnA : Pawn
    {
        private readonly string[] validAPawnInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        public string[] ValidAPawnInputs
        {
            get
            {
                return this.validAPawnInputs;
            }
        }
    }
}
