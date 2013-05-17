//-----------------------------------------------------------------------
// <copyright file="King.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// The game class for the King figure.
    /// </summary>
    public class King : Figure
    {
        /// <summary>
        /// The king's sign on the game board.
        /// </summary>
        private readonly char figureSign = 'K';

        /// <summary>
        /// The valid console inputs for the king figure.
        /// </summary>
        private string[] validFigureInputs = 
        {                               
            "KUL",                                  
            "KUR",       
            "KDL", 
            "KDR" 
        };

        /// <summary>
        /// The position of the King on the game board.
        /// </summary>
        private int[] figurePosition = 
        { 
            9, 
            10 
        };

        /// <summary>
        /// The King's existing moves.
        /// </summary>
        private bool[] figureExistingMoves = 
        { 
            true, 
            true, 
            true, 
            true 
        };

        /// <summary>
        /// Gets the King's sign on the board.
        /// </summary>
        /// <value>The King's sign on the board.</value>
        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        /// <summary>
        /// Gets or sets the valid console inputs for the King figure.
        /// </summary>
        /// <value>The valid console inputs for the King figure.</value>
        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("The valid King inputs are mandatory!");
                }

                this.validFigureInputs = value;
            }
        }

        /// <summary>
        /// Gets or sets the figures position on the game board.
        /// </summary>
        /// <value>The figures position on the game board.</value>
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
                    throw new ArgumentNullException("King postion must not be null or empty!");
                }

                // Check is figure position in board.
                if ((value[1] < 4 || value[1] > 18) || (value[0] < 2 || value[0] > 9))
                {
                    throw new ArgumentException("You try to set king position out of board.");
                }

                this.figurePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the King's existing moves. 
        /// </summary>
        /// <value>The King's existing moves.</value>
        public override bool[] FigureExistingMoves
        {
            get
            {
                return this.figureExistingMoves;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("The King existing moves are mandatory!");
                }

                this.figureExistingMoves = value;
            }
        }

        /// <summary>
        /// Not implemented. Show get the figures new position.
        /// </summary>
        /// <param name="command">A valid figure command.</param>
        /// <returns>Returns the new figure coordinates.</returns>
        public override int[] GetFigureNewCoords(string command)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}