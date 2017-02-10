using CardCore.Enums;
using CardProject;
using CardProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CardProjectTests
{
    [TestClass]
    public class UtilsTests
    {
        /// <summary>
        /// This tests the swap utility to ensure that it actually swaps the values
        /// </summary>
        [TestMethod]
        public void SwapWithAnotherCardTest()
        {
            var cardList = new List<Card>() { new Card(){ Suit = CardSuit.Clubs, Value = CardValue.Ace },
                                              new Card(){ Suit = CardSuit.Diamonds, Value = CardValue.Four}};

            cardList.Swap(0, 1);

            Assert.AreEqual(42, cardList[0].Id);
            Assert.AreEqual(11, cardList[1].Id);
        }

        /// <summary>
        /// This tests the swap utility to ensure that it works if the card is swapped with itself.
        /// </summary>
        [TestMethod]
        public void SwapWithSameCardTest()
        {
            var cardList = new List<Card>() { new Card(){ Suit = CardSuit.Clubs, Value = CardValue.Ace },
                                              new Card(){ Suit = CardSuit.Diamonds, Value = CardValue.Four}};

            cardList.Swap(0,0);

            Assert.AreEqual(11, cardList[0].Id);
            Assert.AreEqual(42, cardList[1].Id);
           
        }

        [TestMethod]
        public void TestRandomNumberGenerator()
        {
            //Since it's impossible to deterministically test generating a random number, we aren't going to do that.
            //We can, however, test a bunch of iterations to verify that the number is within the acceptable range.

            for (int i = 0; i < 100000; i++)
            {
                var randomInt = RandomNumberUtils.GetRandomInt(0, 51);
                Assert.IsTrue(randomInt >= 0);
                Assert.IsTrue(randomInt <= 51);
            }

        }

        /// <summary>
        /// This tests to ensure that ints are being concatenated
        /// </summary>
        [TestMethod]
        public void ConcatIntTest()
        {
            //Since these are one-liners, didn't see the need to create separate tests for each bound.

            //Test low bound
            Assert.AreEqual(11, Helpers.ConcatInt(1, 1));

            //Test mid bound
            Assert.AreEqual(43, Helpers.ConcatInt(4, 3));

            //Test upper bound
            Assert.AreEqual(134, Helpers.ConcatInt(13, 4));
        }

        /// <summary>
        /// This tests the functionality that lists out all the enums
        /// </summary>
        [TestMethod]
        public void GetEnumValuesTest()
        {
            var cardSuitValues = Helpers.GetEnumValues<CardSuit>();
            CardSuit[] referenceArray = new CardSuit[] { CardSuit.Clubs, CardSuit.Diamonds, CardSuit.Hearts, CardSuit.Spades };

            for (int i = 0; i < referenceArray.Length; i++)
            {
                Assert.AreEqual(referenceArray[i], cardSuitValues[i]);
            }
        }

        /// <summary>
        /// This tests the card deck genearator result length.  Expects 52 cards.
        /// </summary>
        [TestMethod]
        public void TestCardDeckGeneratorLength()
        {
            var deck = CardDeckGenerator.GenerateCardDeck();

            Assert.AreEqual(52, deck.Count);
        }

        /// <summary>
        /// This tests the bounds of the card generator.
        /// </summary>
        [TestMethod]
        public void TestCardGeneratorBounds()
        {
            var deck = CardDeckGenerator.GenerateCardDeck();

            Assert.AreEqual(11, deck.First().Id);

            Assert.AreEqual(134, deck.Last().Id);
        }

        /// <summary>
        /// This tests to ensure the generator generates a sorted deck of cards.
        /// </summary>
        [TestMethod]
        public void TestCardGeneratorSort()
        {
            var deck = CardDeckGenerator.GenerateCardDeck();

            for (int i = 0; i < deck.Count; i++)
            {
                //Prevents bounding error
                if (i == 0)
                    continue;

                Assert.IsTrue(deck[i - 1].Id < deck[i].Id);
            }
        }
    }
}