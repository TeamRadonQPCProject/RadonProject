//-----------------------------------------------------------------------
// <copyright file="Pawn.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;
    
    /// <summary>
    /// A parent class for all the pawns in the game.
    /// </summary>
    public class Pawn : Figure
    {
        /// <summary>
        /// The PawnA sign.
        /// </summary>
        private char figureSign;

        /// <summary>
        /// The valid PawnA move commands.
        /// </summary>
        private string[] validFigureInputs;

        /// <summary>
        /// PawnA's position.
        /// </summary>
        private int[] figurePosition;

        /// <summary>
        /// PawnA existing moves.
        /// </summary>
        private bool[] figureExistingMoves = 
        {
            true, true 
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn"/> class with its starting parameters.
        /// </summary>
        /// <param name="figureSign">Sets the current figure sign.</param>
        /// <param name="validFigureInputs">Sets the current figure valid inputs.</param>
        /// <param name="figurePosition">Sets the figures position in the world.</param>
        public Pawn(char figureSign, string[] validFigureInputs, int[] figurePosition)
        {
            this.FigureSign = figureSign;
            this.ValidFigureInputs = validFigureInputs;
            this.FigurePosition = figurePosition;
        }

        /// <summary>
        /// Gets or sets the Pawn's sign.
        /// </summary>
        /// <value>PawnA's sign.</value>
        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }

            set
            {
                this.figureSign = value;
            }
        }

        /// <summary>
        /// Gets or sets the Pawn's position.
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
                if ((value[1] < 4 || value[1] > 18) && (value[0] < 2 || value[0] > 9))
                {
                    throw new ArgumentException("You try to set king position out of board.");
                }

                this.figurePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the Pawn existing moves.
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
        /// Gets the valid inputs for the Pawn.
        /// </summary>
        /// <value>The valid PawnA's inputs.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }

            set
            {
                this.validFigureInputs = value;
            }
        }

        /// <summary>
        /// Gets the new pawn position.
        /// </summary>
        /// <param name="command">Takes a valid pawn command.</param>
        /// <returns>Returns the new valid pawn position.</returns>
        public override int[] GetFigureNewCoords(string command)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };

            int[] oldCoordinates = new int[2];

            oldCoordinates[0] = this.FigurePosition[0];
            oldCoordinates[1] = this.FigurePosition[1];

            int[] newCoords = new int[3];

            if (command[2] == 'L')
            {
                newCoords[0] = oldCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = oldCoordinates[1] + displasmentDownLeft[1];
                newCoords[2] = 0;
                return newCoords;
            }
            else if (command[2] == 'R')
            {
                newCoords[0] = oldCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = oldCoordinates[1] + displasmentDownRight[1];
                newCoords[2] = 1;
                return newCoords;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Moveing command was invalid");
            }
        }
    }
}
