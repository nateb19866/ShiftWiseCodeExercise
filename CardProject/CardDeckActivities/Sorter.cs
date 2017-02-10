using System.Collections.Generic;
using System.Linq;

namespace CardProject.CardDeckActivities
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts a deck of cards
        /// </summary>
        /// <param name="listToSort">The deck of cards to sort</param>
        /// <returns>A sorted deck of cards</returns>
        public static List<Card> SortDeck(List<Card> listToSort)
        {
            //Yay for built-in sort capabilities! The unique ID of each card guarantees that
            //sorting the list ascending by ID will sort the cards in ascending order
            return listToSort.OrderBy(i => i.Id).ToList();
        }
    }
}