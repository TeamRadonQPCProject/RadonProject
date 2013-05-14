//-----------------------------------------------------------------------
// <copyright file="PawnC.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for the third game pawn.
    /// </summary>
    public class PawnC : Pawn
    {
        /// <summary>
        /// The PawnC sign.
        /// </summary>
        private readonly char figureSign = 'C';

        /// <summary>
        /// The valid PawnC move commands.
        /// </summary>
        private readonly string[] validFigureInputs = 
        {
            "CDL",
            "CDR"
        };

        /// <summary>
        /// PawnC's position.
        /// </summary>
        private int[] figurePosition = 
        {
            2, 12
        };

        /// <summary>
        /// PawnC existing moves.
        /// </summary>
        private bool[] figureExistingMoves = 
        {
            true, true
        };

        /// <summary>
        /// Gets PawnC's sign.
        /// </summary>
        /// <value>PawnB's sign.</value>
        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        /// <summary>
        /// Gets or sets PawnC's position.
        /// </summary>
        /// <value>The PawnB's position.</value>
        public override int[] FigurePosition
        {
            get
            {
                return this.figurePosition;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("PawnB postion must not be null or empty!");
                }

                // Check is figure position in board.
                if ((value[0] < 4 || value[0] > 18) && (value[1] < 2 || value[1] > 9))
                {
                    throw new ArgumentException("You try to set king position out of board.");
                }

                this.figurePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets PawnC's existing moves.
        /// </summary>
        /// <value>PawnC's existing moves.</value>
        public override bool[] FigureExistingMoves
        {
            get
            {
                return this.figureExistingMoves;
            }

            set
            {
                this.figureExistingMoves = value;
            }
        }

        /// <summary>
        /// Gets the valid inputs for PawnC.
        /// </summary>
        /// <value>The valid PawnC's inputs.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }
    }
}
