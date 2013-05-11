namespace KingSurvival
{
    using System;

    public abstract class Figure
    {
        // fileds
        public virtual char FigureSign { get; private set; }

        public virtual int[] FigurePosition { get; set; }

        public virtual string[] ValidFigureInputs { get; private set; }

        public virtual bool[] FigureExistingMoves { get; set; }

        public abstract int[] MoveFigure(string command);
    }
}
