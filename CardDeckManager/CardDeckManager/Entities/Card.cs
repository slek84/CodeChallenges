using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CardDeckManager.Entities
{
    /// <summary>
    /// The entity representing a single playing card. For now considered immutable so not messing with hashing or unique ID
    /// </summary>
    public class Card : IComparable
    {
        private Suite _suite;
        private CardValue _cardValue;

        /// <summary>
        /// Suite accessing property
        /// </summary>
        public Suite CardSuite { get { return _suite; } private set { _suite = value; } }

        /// <summary>
        /// Card Face Value accessing property
        /// </summary>
        public CardValue CardFaceValue { get { return _cardValue; } private set { _cardValue = value; } }

        /// <summary>
        /// Get the friendly spoken name of the card with suite abbreviated8
        /// </summary>
        public string FriendlyName {
            get {
                return string.Format("{0} of {1}", CardFaceValue.ToString(), CardSuite.ToString().First());
            }
        }

        /// <summary>
        /// Constructor accepting values to represent the card
        /// </summary>
        /// <param name="cCardSuite">Suite</param>
        /// <param name="cCardValue">CardValue</param>
        public Card(CardValue cardValue, Suite cardSuite)
        {
            CardFaceValue = cardValue;
            CardSuite = cardSuite;
        }

        /// <summary>
        /// Comparison method for utilizing in sorting algorithms
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var comparison = obj as Card;
            if ((int)CardFaceValue == (int)comparison.CardFaceValue) return 0;
            if ((int)CardFaceValue > (int)comparison.CardFaceValue) return 1;

            return -1;
        }

        /// <summary>
        /// Equality comparison override
        /// </summary>
        /// <param name="obj">object castable as Card</param>
        /// <returns>boolean</returns>
        public override bool Equals(object obj)
        {
            // check for null and compare run-time types
            if (obj == null || GetType() != obj.GetType()) return false;
            var comparison = obj as Card;
            return (((int)CardFaceValue == (int)comparison.CardFaceValue) &&
                ((int)CardSuite == (int)comparison.CardSuite));
        }

        /// <summary>
        /// Operator for object reference equality. Since this class is immutable we will use Equals
        /// </summary>
        /// <returns></returns>
        public static bool operator ==(Card card1, Card card2)
        {
            if (System.Object.ReferenceEquals(card1, card2))
            {
                return true;
            }
            else if ((object)card1 == null || (object)card2 == null)
            {
                return false;
            }
            return card1.Equals(card2);
        }

        /// <summary>
        /// Operator for object reference inequality. Produces the inverse of == operator.
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }

    /// <summary>
    /// The enumeration of possible card Suites
    /// </summary>
    public enum Suite
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    /// <summary>
    /// The enumeration of Card "Face" Value according to order. Aces high. For this enum Two is considered default value.
    /// </summary>
    [DefaultValue(2)]
    public enum CardValue
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
}
