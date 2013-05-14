namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnsTest
    {
        [TestMethod]
        public void PawnA_TestPawnStartPosition()
        {
            Pawn firstPawn = new Pawn('A', new string[] { "ADL", "ADR" }, new int[] { 2, 4 });

            int[] actual = { 2, 4 };

            Assert.AreEqual(firstPawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnB_TestPawnStartPosition()
        {
            Pawn secondPawn = new Pawn('B', new string[] { "BDL", "BDR" }, new int[] { 2, 8 });

            int[] actual = { 2, 8 };

            Assert.AreEqual(secondPawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnC_TestPawnStartPosition()
        {
            Pawn thirdPawn = new Pawn('C', new string[] { "CDL", "CDR" }, new int[] { 2, 12 });

            int[] actual = { 2, 12 };

            Assert.AreEqual(thirdPawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnD_TestPawnStartPosition()
        {
            Pawn fourthPawn = new Pawn('D', new string[] { "DDL", "DDR" }, new int[] { 2, 16 });

            int[] actual = { 2, 16 };

            Assert.AreEqual(fourthPawn.FigurePosition[0], actual[0]);
        }
    }
}
