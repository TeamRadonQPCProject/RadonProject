﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvival.Tests
{
    [TestClass]
    public class GameBoardTest
    {
        [TestMethod]
        public void GameBoard_TestCheckPositionNegativeNumbers()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.IsFalse(gameBoard.CheckPositionInBoard(new int[] { -10, -10 }));
        }

        [TestMethod]
        public void GameBoard_TestCheckPostionOutOfBoard()
        {
            GameBoard gameBoard = new GameBoard();

            Assert.IsFalse(gameBoard.CheckPositionInBoard(new int[] { 2000, 2000 }));
        }
    }
}
