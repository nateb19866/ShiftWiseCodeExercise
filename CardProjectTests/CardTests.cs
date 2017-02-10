using CardCore.Enums;
using CardProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardProjectTests
{
    [TestClass]
    public class CardTests
    {
        /// <summary>
        /// Tests computing the lowest possible number
        /// </summary>
        [TestMethod]
        public void LowestIDCheck()
        {
            var card = new Card() { Suit = CardSuit.Clubs, Value = CardValue.Ace };

            Assert.AreEqual(11, card.Id);
        }

        /// <summary>
        /// Tests computing a middle number
        /// </summary>
        [TestMethod]
        public void MiddleIDCheck()
        {
            var card = new Card() { Suit = CardSuit.Diamonds, Value = CardValue.Seven };

            Assert.AreEqual(72, card.Id);
        }

        /// <summary>
        /// Tests computing the highest number
        /// </summary>
        [TestMethod]
        public void UpperIDCheck()
        {
            var card = new Card() { Suit = CardSuit.Spades, Value = CardValue.King };

            Assert.AreEqual(134, card.Id);
        }
    }
}