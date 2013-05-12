//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace KingSurvival.Tests
//{
//    [TestClass]
//    public class TestCheckAndProcess : King
//    {
//        [TestMethod]
//        public void CheckInput_PawnAInputsDownLeftTest()
//        {
//            string input = "ADL";
//            string[] validInputs = { "ADL", "ADR" };
//            GameEngine gameLogicTest = new GameEngine();
//            Assert.IsTrue(gameLogicTest.ChechInput(input, validInputs));
//        }

//        [TestMethod]
//        public void CheckInput_PawnAInvalidInputsDownLeftTest()
//        {
//            string input = "ADLg";
//            string[] validInputs = { "ADL", "ADR" };
//            GameEngine gameLogicTest = new GameEngine();
//            Assert.IsFalse(gameLogicTest.ChechInput(input, validInputs));
//        }

//        private int indexKing = 0;
//        public override string ReadKingInput()
//        {
//            string[] sampleInput = new string[] {
//            "kur",
//            "kur",
//            "kul",
//            "kdr",
//            "kdr",
//            "kdr"
//            };

//            return sampleInput[indexKing++];
//        }

//        //private int indexPawn = 0;
//        //public override string ReadPawnInput()
//        //{
//        //    string[] sampleInput = new string[] {
//        //    "cdr",
//        //    "cdr",
//        //    "cdl",
//        //    "cdr",
//        //    "cdr",
//        //    "cdl"
//        //    };

//        //    return sampleInput[indexPawn++];
//        //}

//        [TestMethod]
//        public void GameLogic_CheckCollisionDetection()
//        {
//            GameEngine gameTester = new GameEngine();
//            gameTester.InteractWithUser();
//            string expectedOutput = @"UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B   C   D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |                 | 5
//6 |                 | 6
//7 |       K         | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B   C   D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |                 | 5
//6 |         K       | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |           C     | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |                 | 5
//6 |         K       | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |           C     | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |           K     | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |             C   | 2
//3 |                 | 3
//4 |                 | 4
//5 |           K     | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |             C   | 2
//3 |                 | 3
//4 |         K       | 4
//5 |                 | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |           C     | 3
//4 |         K       | 4
//5 |                 | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |           C     | 3
//4 |                 | 4
//5 |           K     | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |             C   | 4
//5 |           K     | 5
//6 |                 | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |             C   | 4
//5 |                 | 5
//6 |             K   | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |               C | 5
//6 |             K   | 6
//7 |                 | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter king's turn:
//UL  0 1 2 3 4 5 6 7  UR
//   _________________
//0 | A   B       D   | 0
//1 |                 | 1
//2 |                 | 2
//3 |                 | 3
//4 |                 | 4
//5 |               C | 5
//6 |                 | 6
//7 |               K | 7
//  |_________________|
//DL  0 1 2 3 4 5 6 7  DR

//Please enter pawn's turn: King loses!
//Game is finished!

//Thank you for using this game!";
//        }

//        [Ignore]
//        [TestMethod]
//        public void TestKingMoveDownLeft()
//        {
//        }

//        [Ignore]
//        [TestMethod]
//        public void TestKingMoveDownRight()
//        {
//        }
//    }
//}
