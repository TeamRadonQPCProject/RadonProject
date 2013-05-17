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
            Assert.IsFalse(myTestEngine.CheckPawnPlayerInput(input));
        }

        [TestMethod]
        public void CheckPawnPlayerInput_PawnValidInputsDownLeftTestTwo()
        {
            string input = "BDL";
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
        public void CheckPawnPlayerInput_PawnValidInputsDownLeftTestThree()
        {
            string input = "CDL";
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
        public void CheckPawnPlayerInput_PawnValidInputsDownLeftTestFour()
        {
            string input = "DDL";
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
        public void CheckPawnPlayerInput_InvalidCommand()
        {
            string input = "xsdw";
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.IsFalse(myTestEngine.CheckPawnPlayerInput(input));
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

        [TestMethod]
        public void HasPawnsExistingMoves_DoesNotHaveMovesKingWin()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 9, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 9, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 9, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            theKing.FigurePosition[0] = 7;
            theKing.FigurePosition[1] = 10;
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            myTestEngine.HasPawnsExistingMove();
            bool expected = true;
            Assert.AreEqual(expected, myTestEngine.GameIsFinished);
        }

        [Ignore]
        [TestMethod]
        public void SetNewKingPostion_DownLeftFromStartPositionDoesNotChangeCoordinates()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedCoords = new int[] { 9, 10 };
            myTestEngine.SetNewKingPosition("KDL");
            CollectionAssert.AreEqual(expectedCoords, theKing.FigurePosition);
        }

        [TestMethod]
        public void CheckForKingExit_KingHasExit()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            Assert.IsTrue(myTestEngine.CheckForKingExit(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckForKingExit_KingPositionIsInvalid()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            myTestEngine.CheckForKingExit(-3);
        }

        [TestMethod]
        public void MovePawnOnBoard_InvalidMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            Assert.IsFalse(myTestEngine.MovePawnOnBoard(new int[] { 2, 8 }, new int[] { 3, 10 }, 'A'));
        }

        [TestMethod]
        public void MovePawnOnBoard_ValidMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            Assert.IsTrue(myTestEngine.MovePawnOnBoard(new int[] { 5, 5 }, new int[] { 2, 2 }, 'A'));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MoveKingOnBoard_OutOfRangeMove()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            myTestEngine.MoveKingOnBoard(new int[] { -100, -100 }, new int[] { });
        }
        [TestMethod]
        public void SetNewPawnPosition_ValidPosition()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();
            Assert.IsTrue(myTestEngine.SetNewPawnPosition("ADR"));

        }

        [TestMethod]
        public void GetNewKingPosition_UpRight()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedNewCoords = { 4, 7 };

            CollectionAssert.AreEqual(expectedNewCoords, myTestEngine.GetNewKingCoords(new int[] { 5, 5 }, "KUR"));

        }

        [TestMethod]
        public void GetNewKingPosition_UpLeft()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedNewCoords = { 7, 6 };

            CollectionAssert.AreEqual(expectedNewCoords, myTestEngine.GetNewKingCoords(new int[] { 8, 8 }, "KUL"));

        }

        [TestMethod]
        public void GetNewKingPosition_DownLeft()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedNewCoords = { 9, 6 };

            CollectionAssert.AreEqual(expectedNewCoords, myTestEngine.GetNewKingCoords(new int[] { 8, 8 }, "KDL"));

        }

        [TestMethod]
        public void GetNewKingPosition_DownRight()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 9, 16 });
            King theKing = new King();
            GameBoard gameBoard = new GameBoard();
            GameEngine myTestEngine = new GameEngine(gameBoard, firstPawn, secondPawn, thirdPawn, fourthPawn, theKing);
            myTestEngine.StartGame();

            int[] expectedNewCoords = { 7, 8 };

            CollectionAssert.AreEqual(expectedNewCoords, myTestEngine.GetNewKingCoords(new int[] { 6, 6 }, "KDR"));

        }
    }
}
