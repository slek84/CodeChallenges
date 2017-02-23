using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardDeckManager.Managers;
using CardDeckManager.Entities;

namespace CardDeckTests
{
    [TestClass]
    public class FiftyTwoCardDeckManager_UnitTests
    {
        /// <summary>
        /// Testing the deck init
        /// </summary>
        [TestMethod]
        public void FiftyTwoDeckManager_TestInitialize()
        {
            // arrange a deck
            var testDeckManager = new FiftyTwoCardDeckManager();

            // act by calling initialize
            testDeckManager.InitializeDeck();

            // assert that it has a count of 52 cards
            Assert.AreEqual(testDeckManager.GetDeck.Count, 52);
        }

        /// <summary>
        /// Test of the 52 deck manager's shuffle by doing a random check of 13 items of values pre and post shuffle. 
        /// 3 May result with the same result position.
        /// </summary>
        [TestMethod]
        public void FiftyTwoDeckManager_TestShuffle()
        {
            // arrange and initialize a deck
            var testDeckManager = new FiftyTwoCardDeckManager();
            testDeckManager.InitializeDeck();

            // arrange the random position list and comparison list
            var random = new Random();
            var randomSelection = new List<int>(13);
            var preSortSelection = new List<Card>(13);
            
            // build the list of random index to be compared from, for 13 cards
            for (var i = 0; i != 13; ++i)
            {
                var randomPick = 0;
                do
                {
                    randomPick = random.Next(0, 52);
                } while (randomSelection.Contains(randomPick));
                randomSelection.Add(randomPick);
            }
            // make the pre sort selection
            foreach (var randomIndex in randomSelection)
            {
                preSortSelection.Add(testDeckManager.GetDeck[randomIndex]);
            }

            // act by calling the shuffle and counting the comparison between the items
            testDeckManager.ShuffleDeck();
            var sameResultCount = 0;

            for (var i = 0; i != randomSelection.Count; ++i)
            {
                var preSortRandomIndex = randomSelection[i];
                if (testDeckManager.GetDeck[preSortRandomIndex] == preSortSelection[i])
                    sameResultCount++;
            }

            // assert that no more than 3 cards out of the random selection are equal
            Assert.IsTrue(sameResultCount <= 3);
        }

        /// <summary>
        /// Tests the sorting of a 52 card deck by initializing one, sorting by ascending value, then running a failure detection algorithm.
        /// </summary>
        [TestMethod]
        public void FiftyTwoDeckManager_TestSortAscending()
        {
            //arrange and initialize a deck manager
            var testDeckManager = new FiftyTwoCardDeckManager();
            testDeckManager.InitializeDeck();

            //act by calling the sort ascending
            testDeckManager.SortDeck_AscendingValue();

            var cardsOrderedAscending = true;
            var groupIteration = 1;
            var cardValues = Enum.GetValues(typeof(CardValue)) as int[];
            // determine if the first card in the sorted deck is the default (lowest) enum value
            var firstDeckCardGroup = testDeckManager.GetDeck[0];
            // if the first card isn't the default value from the enum it wasn't sorted ascending
            if ((int)firstDeckCardGroup.CardFaceValue != cardValues[0]) { cardsOrderedAscending = false; }
            else
            {
                firstDeckCardGroup = null;
                // else iterate through the deck and confirm that all cards are in groups ascending order, according to face value
                foreach (var card in testDeckManager.GetDeck)
                {
                    // if the group Iteration is 1 then we are starting a new value group so store that value
                    // check if it is sequencial to the previous used, if not its a failure breaking condition
                    if (groupIteration == 1)
                    {
                        // if the firstDeckCardGroup reference is null then no need for comparison
                        if (firstDeckCardGroup != null)
                        {
                            if ((int)firstDeckCardGroup.CardFaceValue >= (int)card.CardFaceValue)
                            {
                                cardsOrderedAscending = false;
                                break;
                            }
                        }
                        firstDeckCardGroup = card;
                    }
                    // else make sure it has the same face value as the first in the group of 4
                    // if not its a failure breaking condition
                    else
                    {
                        if ((int)firstDeckCardGroup.CardFaceValue != (int)card.CardFaceValue)
                        {
                            cardsOrderedAscending = false;
                            break;
                        }
                    }

                    if (groupIteration == Enum.GetValues(typeof(Suite)).Length) groupIteration = 1;
                    else ++groupIteration;
                }
            }

            Assert.IsTrue(cardsOrderedAscending);
        }
    }
}
