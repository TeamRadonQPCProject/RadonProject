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
            PawnA firstPawn = new PawnA();
            PawnB secondPawn = new PawnB();
            PawnC thirdPawn = new PawnC();
            PawnD fourthPawn = new PawnD();
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            myTestEngine.InteractWithUser();
        }
    }
}
