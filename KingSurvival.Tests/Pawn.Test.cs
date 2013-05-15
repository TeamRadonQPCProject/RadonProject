namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnsTest
    {
        [TestMethod]
        public void Pawn_SignGetTest()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            Assert.AreEqual('A', pawn.FigureSign);
        }

        [TestMethod]
        public void Pawn_TestPositionSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });

            int[] actual = { 2, 4 };

            Assert.AreEqual(pawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestEmptyPositionSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestNullPositionSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pawn_TestInvalidPositionSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestEmptyValidInputsSet()
        {
            Pawn pawn = new Pawn('A', new string[] { }, new int[] { 2, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestNullValidInputsSet()
        {
            Pawn pawn = new Pawn('A', null, new int[] { 2, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestNullExistingMovesSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            pawn.FigureExistingMoves = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pawn_TestEmptyExistingMovesSet()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            pawn.FigureExistingMoves = new bool[] { };
        }

        [TestMethod]
        public void Pawn_GetNewPositionTestLeftCommand()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            int[] newCoords = pawn.GetFigureNewCoords("ADR");
            int[] expected = { 3, 6, 1 };

            CollectionAssert.AreEqual(expected, newCoords);
        }

        [TestMethod]
        public void Pawn_GetNewPositionTestRightCommand()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            int[] newCoords = pawn.GetFigureNewCoords("ADL");
            int[] expected = { 3, 2, 0 };

            CollectionAssert.AreEqual(expected, newCoords);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pawn_GetNewPositionTestInvalidCommand()
        {
            Pawn pawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });
            int[] newCoords = pawn.GetFigureNewCoords("abs");
        }
    }
}
