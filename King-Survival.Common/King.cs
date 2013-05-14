//-----------------------------------------------------------------------
// <copyright file="King.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    public class King : Figure
    {
        private readonly char figureSign = 'K';

        private readonly string[] validFigureInputs = 
        {                               
            "KUL",                                  
            "KUR",       
            "KDL", 
            "KDR" 
        };

        private int[] figurePosition = 
        { 
            9, 
            10 
        };

        private bool[] figureExistingMoves = 
        { 
            true, 
            true, 
            true, 
            true 
        };

        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        public override string[] ValidFigureInputs
        {
            get
            {
                return validFigureInputs;
            }
        }

        public override int[] FigurePosition
        {
            get
            {
                return figurePosition;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("King postion must not be null or empty!");
                }

                // Check is figure position in board.
                if ((value[0] < 4 || value[0] > 18) && (value[1] < 2 || value[1] > 9))
                {
                    throw new ArgumentException("You try to set king position out of board.");
                }

                figurePosition = value;
            }
        }

        public override bool[] FigureExistingMoves
        {
            get
            {
                return figureExistingMoves;
            }

            set
            {
                figureExistingMoves = value;
            }
        }

        public override int[] GetFigureNewCoords(string command)
        {
            throw new NotImplementedException();
        }
    }
}