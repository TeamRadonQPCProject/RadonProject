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
