using CardProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardProject.CardDeckActivities
{
    public static class Shuffler
    {
        /// <summary>
        /// Shuffles an arbitrary deck of cards
        /// </summary>
        /// <param name="listToShuffle">The list of cards to shuffle</param>
        /// <returns>A shuffled list of cards</returns>
        public static List<Card> ShuffleCards(List<Card> listToShuffle)
        {

            //Null check
            if (listToShuffle == null || !listToShuffle.Any())
                throw new ArgumentNullException("Please pass in a valid deck!");
            
            //Basic idea here is that if we run through the deck and randomly swap each card with another card,
            //and repeat the process to increase randomness, we can shuffle the deck to an acceptable level of randomness

            //Adding the ability to run through the deck in multiple iterations allows for extra randomness
            for (int iteration = 0; iteration < 5000; iteration++)
            {
                //Here we're looping through each card in the deck and randomly swapping it with another card. Note that
                //swapping a card with itself is statistically valid.
                for (int i = 0; i < listToShuffle.Count; i++)
                {
                    listToShuffle.Swap(i, RandomNumberUtils.GetRandomInt(0, listToShuffle.Count - 1));
                }
            }

            return listToShuffle;
        }
    }
}