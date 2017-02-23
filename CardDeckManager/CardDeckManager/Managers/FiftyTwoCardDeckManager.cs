using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDeckManager.Entities;

namespace CardDeckManager.Managers
{
    public class FiftyTwoCardDeckManager : ICardDeckManager
    {
        /// <summary>
        /// Private List of Cards held in memory to be operated on.
        /// </summary>
        private IList<Card> _cardDeck;

        /// <summary>
        /// Property for retrieving the memory held deck of cards.
        /// </summary>
        /// <returns>IList</returns>
        public IList<Card> GetDeck { get { return _cardDeck; } }

        /// <summary>
        /// Generate the private "internal" deck object and hold in memory as the private list.
        /// </summary>
        public void InitializeDeck()
        {
            _cardDeck = new List<Card>(52);

            // we will create 13 cards in each suite
            foreach (Suite suiteIteration in Enum.GetValues(typeof(Suite)))
            {
                // and we will create a card for each face value
                foreach (CardValue cardFaceIteration in Enum.GetValues(typeof(CardValue)))
                {
                    _cardDeck.Add(new Card(cardFaceIteration, suiteIteration));
                }
            }
        }

        /// <summary>
        /// Shuffles the deck using List OrderBy with a passed 
        /// </summary>
        public void ShuffleDeck()
        {
            var randomGen = new Random();

            _cardDeck = _cardDeck.OrderBy(x => randomGen.Next(0,52)).ToList();
        }

        /// <summary>
        /// Use list OrderBy the card "face" value in accordance with its integer value
        /// </summary>
        public void SortDeck_AscendingValue()
        {
            _cardDeck = _cardDeck.OrderBy(x => (int)x.CardFaceValue).ToList();
        }
    }
}
