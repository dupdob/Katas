using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PokerHandKata.Logic
{
    public enum CardColor
    {
        Clover,
        Diamond,
        Heart,
        Spade
    }

    public enum CardLabel
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace    
    }

    public class PokerHand
    {
        private List<Card> cards;

        /// <summary>
        /// Parses a string to build a PokerHand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool Parse(string hand)
        {
            var cardText = hand.Split(' ');

            if (cardText.Length != 5)
                return false;
            this.cards = new List<Card>(cardText.Length);
            foreach (var text in cardText)
            {
                var card = new Card();
                if (!card.Parse(text))
                    return false;
                this.cards.Add(card);
            }
            this.cards.Sort();
            this.cards.Reverse();
            return true;
        }

        public CardLabel? FindPair()
        {
            for (var i = 0; i < this.cards.Count; i++)
            {
                for (var j = i + 1; j < this.cards.Count; j++)
                {
                    if (this.cards[i].Label == this.cards[j].Label)
                        return this.cards[i].Label;
                }
            }
            return null;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < this.cards.Count; i++)
            {
                builder.Append(this.cards[i]);
                if (i < this.cards.Count-1)
                    builder.Append(' ');
            }
            return builder.ToString();
        }

        public IEnumerable<Combination> ToCombinations()
        {
            var ret = new List<Combination>(5);
            foreach (var card in this.cards)
            {
                var combo = new Combination
                {
                    Figure = Figure.SingleCard,
                    Height = card.Label
                };
                ret.Add(combo);
            }
            return ret;
        }
    }

    public enum Figure {SingleCard, Pair, ThreeOfAKind, Straight, Flush, Full, FourOfAKind, StraightFlush }
    public class Combination
    {
        public Figure Figure { get; set; }
        public CardLabel Height { get; set; }
    }
}