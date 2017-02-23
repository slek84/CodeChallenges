using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardDeckManager.Entities;

namespace CardDeckTests
{
    [TestClass]
    public class CardEntity_UnitTests
    {
        /// <summary>
        /// Test that the correct friendly name string can be retrieved from a created card
        /// </summary>
        [TestMethod]
        public void TestCardFriendlyNameProperty()
        {
            //arrange a card entity
            var testCard = new Card(CardValue.Ace, Suite.Spades);

            //act on the friendly name property
            var friendlyName = testCard.FriendlyName;

            //assert expected string
            Assert.AreEqual(friendlyName, "Ace of S");
        }

        /// <summary>
        /// Test that the correct string for face value can be retrieved after constructing a card
        /// </summary>
        [TestMethod]
        public void TestCardFaceValueProperty()
        {
            //arrange a card entity
            var testCard = new Card(CardValue.King, Suite.Diamonds);

            //retrieve the face value from the exposed property
            var cardFaceValue = testCard.CardFaceValue.ToString();

            //assert expected string
            Assert.AreEqual(cardFaceValue, "King");
        }

        /// <summary>
        /// Test that the correct string for card suite can be retrieved after constructing a card
        /// </summary>
        [TestMethod]
        public void TestCardSuiteProperty()
        {
            //arrange a card entity
            var testCard = new Card(CardValue.Queen, Suite.Hearts);

            //retrieve the face value from the exposed property
            var cardSuite = testCard.CardSuite.ToString();

            //assert expected string
            Assert.AreEqual(cardSuite, "Hearts");
        }

        /// <summary>
        /// Test that operator equality through objects works with different suites
        /// </summary>
        [TestMethod]
        public void TestCardObjectEqualOperator_NotEqual()
        {
            //arrange a couple cards
            var firstCard = new Card(CardValue.Seven, Suite.Diamonds);
            var secondCard = new Card(CardValue.Seven, Suite.Hearts);

            //act on comparing them with the operator
            var opEq = firstCard == secondCard;

            //assert that the equality is true
            Assert.IsFalse(opEq);
        }

        /// <summary>
        /// Test that operator equality through objects works with same values and same suites
        /// </summary>
        [TestMethod]
        public void TestCardObjectEqualOperator_Equal()
        {
            //arrange a couple cards
            var firstCard = new Card(CardValue.Seven, Suite.Clubs);
            var secondCard = new Card(CardValue.Seven, Suite.Clubs);

            //act on comparing them with the operator
            var opEq = firstCard == secondCard;

            //assert that the equality is true
            Assert.IsTrue(opEq);
        }

        [TestMethod]
        public void TestCardNullEqualOperator_NotEqual()
        {
            //arrange a card and a card whose reference is null
            var firstCard = new Card(CardValue.Seven, Suite.Clubs);
            Card secondCard = null;

            //act on comparing them with the operator
            var opEq = firstCard == secondCard;

            // assert is false
            Assert.IsFalse(opEq);
        }
    }
}
