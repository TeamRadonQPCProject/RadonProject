﻿namespace KingSurvival
{
    using System;

    public class PawnC : Figure
    {
        private char figureSign = 'C';

        private string[] validFigureInputs = 
        {
            "CDL",
            "CDR"
        };

        private int[] figurePosition = 
        {
            2, 12
        };

        private bool[] figureExistingMoves = 
        {
            true, true
        };

        public override char FigureSign
        {
            get
            {
                return this.figureSign;
            }
        }

        // properties
        public override int[] FigurePosition
        {
            get
            {
                return this.figurePosition;
            }
            set
            {
                this.figurePosition = value;
            }
        }

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

        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }

        // methods
        public override bool MoveFigure(string command)
        {
            throw new NotImplementedException();
        }
    }
}
