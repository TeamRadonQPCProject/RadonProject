//-----------------------------------------------------------------------
// <copyright file="PawnA.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for the first game pawn.
    /// </summary>
    public class PawnA : Pawn
    {
        /// <summary>
        /// The PawnA sign.
        /// </summary>
        private readonly char figureSign = 'A';

        /// <summary>
        /// The valid PawnA move commands.
        /// </summary>
        private readonly string[] validFigureInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        /// <summary>
        /// PawnA's position.
        /// </summary>
        private int[] figurePosition = 
        {
             2, 4 
        };

        /// <summary>
        /// PawnA existing moves.
        /// </summary>
        private bool[] figureExistingMoves = 
        {
            true, true 
        };

        /// <summary>
        /// Gets PawnA's sign.
        /// </summary>
        /// <value>PawnA's sign.</value>
        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        /// <summary>
        /// Gets or sets PawnA's position.
        /// </summary>
        /// <value>The PawnA's position.</value>
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
                    throw new ArgumentNullException("PawnA postion must not be null or empty!");
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
        /// Gets or sets PawnA's existing moves.
        /// </summary>
        /// <value>PawnA's existing moves.</value>
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
        /// Gets the valid inputs for PawnA.
        /// </summary>
        /// <value>The valid PawnA's inputs.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }
    }
}
