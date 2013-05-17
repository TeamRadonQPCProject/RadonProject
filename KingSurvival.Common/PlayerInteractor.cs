//-----------------------------------------------------------------------
// <copyright file="PlayerInteractor.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace KingSurvival
{
    using System;

    /// <summary>
    /// A class for player interaction.
    /// </summary>
    public class PlayerInteractor
    {
        /// <summary>
        /// Starts the current game.
        /// </summary>
        public void StartGame()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.InitGame();
            myTestEngine.StartGame();
        }
    }
}
