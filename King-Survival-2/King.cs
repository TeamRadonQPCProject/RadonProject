﻿namespace KingSurvival
{
    using System;

    public class King : Figure
    {
        private char figureSign = 'K';

        private string[] validFigureInputs = 
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

        public override bool MoveFigure(string command)
        {
            throw new NotImplementedException();
        }
    }
}
