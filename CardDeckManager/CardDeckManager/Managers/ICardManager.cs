using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDeckManager.Entities;

namespace CardDeckManager.Managers
{
    /// <summary>
    /// Contains the method declaration signatures for implementing card manager classes
    /// </summary>
    interface ICardDeckManager
    {
        /// <summary>
        /// Generate the internal deck object and hold in memory.
        /// </summary>
        void InitializeDeck();

        /// <summary>
        /// Shuffle the deck according to a displacement scheme that executes once, fast and efficient.
        /// </summary>
        void ShuffleDeck();

        /// <summary>
        /// Rearange the deck, organized by ascending card value. Aces high.
        /// </summary>
        void SortDeck_AscendingValue();

        /// <summary>
        /// Property for retrieving the memory held deck of cards.
        /// </summary>
        /// <returns>IList</returns>
        IList<Card> GetDeck { get; }
    }
}
