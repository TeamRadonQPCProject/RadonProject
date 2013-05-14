namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnATest
    {
        [TestMethod]
        public void PawnA_TestPawnStartPosition()
        {
            PawnA pawn = new PawnA();

            int[] actual = { 2, 4 };

            Assert.AreEqual(pawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnB_TestPawnStartPosition()
        {
            PawnB pawn = new PawnB();

            int[] actual = { 2, 8 };

            Assert.AreEqual(pawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnC_TestPawnStartPosition()
        {
            PawnC pawn = new PawnC();

            int[] actual = { 2, 12 };

            Assert.AreEqual(pawn.FigurePosition[0], actual[0]);
        }

        [TestMethod]
        public void PawnD_TestPawnStartPosition()
        {
            PawnD pawn = new PawnD();

            int[] actual = { 2, 16 };

            Assert.AreEqual(pawn.FigurePosition[0], actual[0]);
        }
    }
}
