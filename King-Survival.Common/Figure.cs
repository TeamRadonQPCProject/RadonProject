//-----------------------------------------------------------------------
// <copyright file="Figure.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// Abstract class for implementing game figure logic.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Gets the figure sign.
        /// </summary>
        /// <value>The sign that represents the current figure.</value>
        public virtual char FigureSign { get; private set; }

        /// <summary>
        /// Gets or sets the position for the current figure.
        /// </summary>
        /// <value>The position for the current figure.</value>
        public virtual int[] FigurePosition { get; set; }

        /// <summary>
        /// Gets the list of valid inputs that the figure can process.
        /// </summary>
        /// <value>A list of valid inputs that the figure can process.</value>
        public virtual string[] ValidFigureInputs { get; private set; }

        /// <summary>
        /// Gets or sets the moves that the figure can make.
        /// </summary>
        /// <value>The moves that the figure can make.</value>
        public virtual bool[] FigureExistingMoves { get; set; }

        /// <summary>
        /// Gets the coordinates for the figure.
        /// </summary>
        /// <param name="command">A valid game figure command.</param>
        /// <returns>Returns the new coordinates of the figure.</returns>
        public abstract int[] GetFigureNewCoords(string command);
    }
}
