using CardProject.CardDeckActivities;
using CardProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardProjectTests
{
    [TestClass]
    public class SorterTests
    {

        /// <summary>
        /// Does a basic null check test
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestSorterNullCheck()
        {
            Sorter.SortDeck(null);
        }

        /// <summary>
        /// Since we're using Linq to sort the cards, this is just a sanity check that ensures the deck is sorted.
        /// </summary>
        [TestMethod]
        public void TestSorterWithInvertedDeck()
        {
            var invertedDeck = CardDeckGenerator.GenerateCardDeck();

            //We're reversing the deck to force the sorter to move every row
            invertedDeck.Reverse();

            var sortedDeck = Sorter.SortDeck(invertedDeck);

            for (int i = 0; i < sortedDeck.Count; i++)
            {
                //Prevents bounding error
                if (i == 0)
                    continue;

                Assert.IsTrue(sortedDeck[i - 1].Id < sortedDeck[i].Id);
            }
        }

        /// <summary>
        /// Basic integration test that verifies that the cards can be shuffled and then sorted.
        /// </summary>
        [TestMethod]
        public void TestSorterWithShuffledDeck()
        {
            var deckToShuffle = CardDeckGenerator.GenerateCardDeck();

            //Note: We have another test that ensures the generator generates a sorted deck of cards, so we can safely use the vanilla output of the
            //generator as a reference
            var deckToCompare = CardDeckGenerator.GenerateCardDeck();

            var shuffledDeck = Shuffler.ShuffleCards(deckToShuffle);

            var sortedDeck = Sorter.SortDeck(shuffledDeck);

            bool differenceFound = false;

            for (int i = 0; i < deckToCompare.Count; i++)
            {
                differenceFound = deckToCompare[i].Id != sortedDeck[i].Id;

                if (differenceFound)
                    break;
            }

            Assert.IsFalse(differenceFound);
        }
    }
}