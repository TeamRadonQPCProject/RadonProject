using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvival.Tests
{
    [TestClass]
    public class PawnATest
    {
        [TestMethod]
        public void PawnA_TestPawnPosition()
        {
            PawnA pawnA = new PawnA();

            int[] actual = { 2, 4 };

            Assert.AreEqual(pawnA.FigurePosition[0], actual[0]);
        }
    }
}
