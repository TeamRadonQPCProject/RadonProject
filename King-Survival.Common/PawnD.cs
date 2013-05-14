//-----------------------------------------------------------------------
// <copyright file="PawnD.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for the fourth game pawn.
    /// </summary>
    public class PawnD : Pawn
    {
        /// <summary>
        /// The PawnD sign.
        /// </summary>
        private readonly char figureSign = 'D';

        /// <summary>
        /// The valid PawnD move commands.
        /// </summary>
        private string[] validFigureInputs = 
        { 
            "DDL", 
            "DDR" 
        };

        /// <summary>
        /// PawnD's position.
        /// </summary>
        private bool[] figureExistingMoves = 
        {
             true, true 
        };

        /// <summary>
        /// PawnD existing moves.
        /// </summary>
        private int[] figurePosition = 
        {
             2, 16 
        };

        /// <summary>
        /// Gets PawnD's sign.
        /// </summary>
        /// <value>PawnD's sign.</value>
        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        /// <summary>
        /// Gets or sets PawnD's position.
        /// </summary>
        /// <value>The PawnD's position.</value>
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
        /// Gets or sets PawnD's existing moves.
        /// </summary>
        /// <value>PawnD's existing moves.</value>
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
        /// Gets the valid inputs for PawnD.
        /// </summary>
        /// <value>The valid PawnD's inputs.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }
    }
}
