using CardCore.Enums;
using System.Collections.Generic;

namespace CardProject.Utils
{
    public static class CardDeckGenerator
    {
        /// <summary>
        /// Generates a standard deck of playing cards.
        /// </summary>
        /// <returns>52 card objects, sorted ascending</returns>
        public static List<Card> GenerateCardDeck()
        {
            var CardDeck = new List<Card>();

            foreach (var value in Helpers.GetEnumValues<CardValue>())
            {
                foreach (var suit in Helpers.GetEnumValues<CardSuit>())
                {
                    CardDeck.Add(new Card() { Suit = suit, Value = value });
                }
            }
            return CardDeck;
        }
    }
}