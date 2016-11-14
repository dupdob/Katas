using System;
using NFluent;
using NUnit.Framework;
using PokerHandKata.Logic;

namespace PokerHandKata.Tests
{
    [TestFixture]
    public class PokerHandShould
    {
        [Test]
        public void ParsePokerHandCorrectly()
        {
            var tester = new PokerHand();
            // check with correct hand
            Check.That(tester.Parse("2H 3D 5S 9C KD")).IsTrue();
            // must fail with four cards
            Check.That(tester.Parse("2H 3D 5S 9C")).IsFalse();
            // should fail with incomplete card
            Check.That(tester.Parse("2H 3D 5S 9C K")).IsFalse();
            // should fail if non legal card
            Check.That(tester.Parse("2H 3D 5S 9C SD")).IsFalse();
            // should fail if non legal color
            Check.That(tester.Parse("2H 3D 5S 9C KZ")).IsFalse();
        }

        [Test]
        public void ParseASingleCard()
        {
            var tester = new Card();

            Check.That(tester.Parse("2H")).IsTrue();

            Check.That(tester.Color).IsEqualTo(CardColor.Heart);

            Check.That(tester.Label).IsEqualTo(CardLabel.Two);
        }

        [Test]
        public void SortCards()
        {
            var tester = new PokerHand();
            tester.Parse("2H 3D 5S 9C KD");
            // should be in reverse order

            Check.That(tester.ToString()).IsEqualTo("KD 9C 5S 3D 2H");

            tester.Parse("2H 3D 5S TC KD");

            Check.That(tester.ToString()).IsEqualTo("KD TC 5S 3D 2H");
        }

        [Test]
        public void ExtractPairsFromHand()
        {
            var tester = new PokerHand();
            // check with correct hand
            tester.Parse("3H 3D 5S 9C KD");
            Check.That(tester.FindPair()).IsEqualTo(CardLabel.Three);
            // check failure with no pair
            tester.Parse("2H 3D 5S 9C KD");
            Check.That(tester.FindPair()).IsEqualTo(null);
        }

        [Test]
        public void ListSimpleCardCombination()
        {
            var tester = new PokerHand();
            tester.Parse("2H 3D 5S 9C KD");
            Check.That(tester.ToCombinations().Extracting("Figure")).ContainsExactly(new {Figure.SingleCard});

        }
    }
}
