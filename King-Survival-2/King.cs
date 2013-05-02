using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    class King : Figure
    {
        private bool[] kingExistingMoves;
        private int[] kingPosition;
        private string[] validKingInputs;

        public string[] ValidKingInputs
        {
            get { return this.validKingInputs; }
            set { this.validKingInputs = value; }
        }
        
        public bool[] KingExistingMoves
        {
            get { return this.kingExistingMoves; }
            set { this.kingExistingMoves = value; }
        }

        public int[] KingPosition
        {
            get { return this.kingPosition; }
            set { this.kingPosition = value; }
        }
    }
}
