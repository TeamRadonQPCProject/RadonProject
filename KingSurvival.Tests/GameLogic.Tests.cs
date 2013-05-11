using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvival.Tests
{
    [TestClass]
    public class TestCheckAndProcess
    {
        [TestMethod]
        public void CheckInput_PawnAInputsDownLeftTest()
        {
            string input = "ADL";
            string[] validInputs = { "ADL", "ADR" };
            GameLogic gameLogicTest = new GameLogic();
            Assert.IsTrue(gameLogicTest.ChechInput(input, validInputs));
        }

        [TestMethod]
        public void CheckInput_PawnAInvalidInputsDownLeftTest()
        {
            string input = "ADLg";
            string[] validInputs = { "ADL", "ADR" };
            GameLogic gameLogicTest = new GameLogic();
            Assert.IsFalse(gameLogicTest.ChechInput(input, validInputs));
        }

        [Ignore]
        [TestMethod]
        public void TestKingMoveUpRight()
        {
        }

        [Ignore]
        [TestMethod]
        public void TestKingMoveDownLeft()
        {
        }

        [Ignore]
        [TestMethod]
        public void TestKingMoveDownRight()
        {
        }
    }
}
