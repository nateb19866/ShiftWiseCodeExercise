using CardCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardShuffler
{
    public static class Shuffler
    {
        public static List<Card> ShuffleCards(List<Card> listToShuffle, int iterations)
        {
            //Loops through the deck for the iterations specified to increase the randomness factor
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                //Loops through all the cards and 
                for (int i = 0; i < listToShuffle.Count; i++)
                {
                    listToShuffle.Swap(i, RandomNumberGenerator.GetRandomInt(0, listToShuffle.Count - 1));
                }
            }
            return listToShuffle;
        }
    }
}
