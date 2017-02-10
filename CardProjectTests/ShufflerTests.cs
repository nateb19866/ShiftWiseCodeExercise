using CardProject.CardDeckActivities;
using CardProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardProjectTests
{
    [TestClass]
    public class ShufflerTests
    {
        /// <summary>
        /// Basic test to ensure that the output list length matches the input list length
        /// </summary>
        [TestMethod]
        public void TestShufflerResultLength()
        {
            var deckToShuffle = CardDeckGenerator.GenerateCardDeck();
            var deckToCompare = CardDeckGenerator.GenerateCardDeck();

            var shuffledDeck = Shuffler.ShuffleCards(deckToShuffle);

            Assert.AreEqual(deckToCompare.Count, shuffledDeck.Count);
        }

        /// <summary>
        /// Does a basic null check test
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestShufflerNullCheck()
        {
            Shuffler.ShuffleCards(null);
        }

        [TestMethod]
        public void TestShufflerCards()
        {
            var deckToShuffle = CardDeckGenerator.GenerateCardDeck();
            var deckToCompare = CardDeckGenerator.GenerateCardDeck();

            //OK, so trying to test nondeterministic methods is deterministically impossible.  With that said,
            //the best solution I can think of at the moment is to shuffle the deck, if it matches with the reference list, shuffle it again.  Repeat that process
            //until the chances of it returning the same deck for all those times is statistically zero.

            var shuffledDeck = Shuffler.ShuffleCards(deckToShuffle);

            bool differenceFound = false;

            for (int tries = 0; tries < 100; tries++)
            {
                //Compare each card with the original
                for (int i = 0; i < deckToCompare.Count; i++)
                {
                    if (deckToCompare[i].Id != deckToShuffle[i].Id)
                    {
                        differenceFound = true;
                        break;
                    }
                }

                //break if a difference is found
                if (differenceFound)
                {
                    break;
                }

                //If a difference is not found, shuffle the cards again
                shuffledDeck = Shuffler.ShuffleCards(shuffledDeck);
            }

            Assert.IsTrue(differenceFound);
        }
    }
}