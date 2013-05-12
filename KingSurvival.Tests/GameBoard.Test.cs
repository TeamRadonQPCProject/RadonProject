using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvival.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GameBoard_CheckPositionTestNegativeNumbers()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.IsFalse(gameBoard.CheckPositionInBoard(new int[] { -10, -10 }));
        }
    }
}
