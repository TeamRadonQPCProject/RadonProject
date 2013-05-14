//-----------------------------------------------------------------------
// <copyright file="Pawnb.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for the second game pawn.
    /// </summary>
    public class PawnB : Pawn
    {
        /// <summary>
        /// The PawnB sign.
        /// </summary>
        private readonly char figureSign = 'B';

        /// <summary>
        /// The valid PawnB move commands.
        /// </summary>
        private readonly string[] validFigureInputs = 
        { 
            "BDL", 
            "BDR" 
        };

        /// <summary>
        /// PawnB's position.
        /// </summary>
        private int[] figurePosition = 
        {
             2, 8 
        };

        /// <summary>
        /// PawnB existing moves.
        /// </summary>
        private bool[] figureExistingMoves = 
        {
             true, true 
        };

        /// <summary>
        /// Gets PawnB's sign.
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
        /// Gets or sets PawnB's position.
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

                this.figurePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets PawnB's existing moves.
        /// </summary>
        /// <value>PawnB's existing moves.</value>
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
        /// Gets the valid inputs for PawnB.
        /// </summary>
        /// <value>The valid PawnB's inputs.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }
    }
}
