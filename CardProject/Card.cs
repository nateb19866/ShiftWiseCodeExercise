using CardCore.Enums;
using CardProject.Utils;

namespace CardProject
{
    public class Card
    {
        public CardSuit Suit { get; set; }

        public CardValue Value { get; set; }

        /// <summary>
        /// The ID is computed by concatenating the card value and suit.  This is useful when trying to sort
        /// the deck of cards 
        /// </summary>
        public int Id
        {
            get
            {
                return Helpers.ConcatInt((int)Value, (int)Suit);
            }
        }
    }
}