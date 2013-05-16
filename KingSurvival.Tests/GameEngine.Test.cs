namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGameLogic
    {
        [TestMethod]
        public void CheckPawnPlayerInput_PawnInputsDownLeftIsValidTest()
        {
            string input = "ADL";
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.IsTrue(myTestEngine.CheckPawnPlayerInput(input));
        }

        [TestMethod]
        public void CheckPawnPlayerInput_PawnInvalidInputsDownLeftTest()
        {
            string input = "ADLg";
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.AreEqual(myTestEngine.CheckPawnPlayerInput(input), false);
        }

        [TestMethod]
        public void CheckForKingExit_WithValidValueForExit()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.IsTrue(myTestEngine.CheckForKingExit(2));
        }

        [TestMethod]
        public void CheckForKingExit_WithInvalidValueForExit()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.IsFalse(myTestEngine.CheckForKingExit(6));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckForKingExit_WithInvalidValueOutsideOfBoard()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            myTestEngine.CheckForKingExit(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckForKingExit_WithInvalidBigValueOutsideOfBoard()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            myTestEngine.CheckForKingExit(1000);
        }

        [TestMethod]
        public void HasKingExistingMove_KingHasNotExistingMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            int[] kingCurrentCoords = new int[] { 18, 10 };
            Assert.IsFalse(myTestEngine.HasKingExistingMove(kingCurrentCoords));
        }

        [TestMethod]
        public void HasKingExistingMove_KingHasExistingMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            // This is start king position
            int[] kingCurrentCoords = new int[] { 9, 10 };
            Assert.IsTrue(myTestEngine.HasKingExistingMove(kingCurrentCoords));
        }

        [TestMethod]
        public void SetNewKingPostion_UpRightMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedCoords = new int[] { 8, 12 };
            myTestEngine.SetNewKingPosition("KUR");
            CollectionAssert.AreEqual(expectedCoords, theKing.FigurePosition);
        }

        public void HasPawnsExistingMoves_TheHaveMoves()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            myTestEngine.HasPawnsExistingMove();
            bool[] expected = { true, true };
            Assert.AreEqual(expected, firstPawn.FigureExistingMoves);
        }
    }
}
