﻿namespace KingSurvival
{
    using System;

    public class PawnA : Figure
    {
        // fields
        private char figureSign = 'A';

        private readonly string[] validFigureInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        private static int[] figurePosition = 
        {
             2, 4 
        };

        private static bool[] figureExistingMoves = 
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

        public override string[] ValidFigureInputs
        {
            get
            {
                return this.validFigureInputs;
            }
        }

        // methods
        public override int[] MoveFigure(string command)
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
            else if(command[2] == 'R')
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
