namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KingTests
    {
        [TestMethod]
        public void King_TestSignGet()
        {
            char expected = 'K';
            King myKing = new King();
            Assert.AreEqual(expected, myKing.FigureSign);
        }

        [TestMethod]
        public void King_TestDefaultValidInputsGet()
        {
            string[] expected = 
            {                               
                "KUL",                                  
                "KUR",       
                "KDL", 
                "KDR" 
            };

            King myKing = new King();
            CollectionAssert.AreEqual(expected, myKing.ValidFigureInputs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestEmptyIvalidInputsArraySet()
        {
            string[] inputs = 
            {                               
            };

            King myKing = new King();
            myKing.ValidFigureInputs = inputs;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestNullIvalidInputsArraySet()
        {
            string[] inputs = null;
            King myKing = new King();
            myKing.ValidFigureInputs = inputs;
        }

        [TestMethod]
        public void King_TestDefaultFigurePositionGet()
        {
            int[] expected = 
            { 
                9, 
                10 
            };

            King myKing = new King();
            CollectionAssert.AreEqual(expected, myKing.FigurePosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestEmptyFigurePostionSet()
        {
            int[] positions = 
            {
            };

            King myKing = new King();
            myKing.FigurePosition = positions;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestNullFigurePostionSet()
        {
            int[] positions = null;

            King myKing = new King();
            myKing.FigurePosition = positions;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void King_TestInvalidFigurePostionSet()
        {
            int[] positions = 
            {
                100,
                -99
            };

            King myKing = new King();
            myKing.FigurePosition = positions;
        }

        [TestMethod]
        public void King_TestDefaultFigureExistingMovesGet()
        {
            bool[] expected = 
            { 
                true, 
                true,
                true,
                true
            };

            King myKing = new King();
            CollectionAssert.AreEqual(expected, myKing.FigureExistingMoves);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestEmptyFigureExistingMovesSet()
        {
            bool[] positions = 
            {
            };

            King myKing = new King();
            myKing.FigureExistingMoves = positions;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void King_TestNullFigureExistingMovesSet()
        {
            bool[] positions = null;

            King myKing = new King();
            myKing.FigureExistingMoves = positions;
        }
    }
}
