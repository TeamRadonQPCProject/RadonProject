namespace KingSurvival
{
    using System;

    public class PawnD : Pawn
    {
        private string[] validDPawnInputs = 
        { 
            "DDL", 
            "DDR" 
        };

        public string[] ValidDPawnInputs
        {
            get
            {
                return this.validDPawnInputs;
            }
        }
    }
}
