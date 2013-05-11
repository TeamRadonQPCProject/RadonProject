namespace KingSurvival
{
    using System;

    public abstract class Figure
    {
        // fileds
        public abstract char FigureSign { get; }

        public abstract int[] FigurePosition { get; set; }

        public abstract int[] MoveFigure(string command);

        public abstract string[] ValidFigureInputs { get; }

        // TODO: Move pawnExistingMoves and its propertie to the inherited classes
        public abstract bool[] FigureExistingMoves { get; set; }
    }
}
