using System;

namespace PokerHandKata.Logic
{
    public class Card: IComparable 
    {
        public CardColor Color { get; private set; }
        public CardLabel Label { get; private set; }

        public bool Parse(string card)
        {
            if (card.Length != 2)
                return false;
            switch (card[0])
            {
                case '2':
                    this.Label = CardLabel.Two;
                    break;
                case '3':
                    this.Label = CardLabel.Three;
                    break;
                case '4':
                    this.Label = CardLabel.Four;
                    break;
                case '5':
                    this.Label = CardLabel.Five;
                    break;
                case '6':
                    this.Label = CardLabel.Six;
                    break;
                case '7':
                    this.Label = CardLabel.Seven;
                    break;
                case '8':
                    this.Label = CardLabel.Eight;
                    break;
                case '9':
                    this.Label = CardLabel.Nine;
                    break;
                case 'T':
                    this.Label = CardLabel.Ten;
                    break;
                case 'J':
                    this.Label = CardLabel.Jack;
                    break;
                case 'Q':
                    this.Label = CardLabel.Queen;
                    break;
                case 'K':
                    this.Label = CardLabel.King;
                    break;
                case 'A':
                    this.Label = CardLabel.Ace;
                    break;
                default:
                    return false;
            }

            switch (card[1])
            {
                case 'H':
                    this.Color = CardColor.Heart;
                    break;
                case 'S':
                    this.Color = CardColor.Spade;
                    break;
                case 'D':
                    this.Color = CardColor.Diamond;
                    break;
                case 'C':
                    this.Color = CardColor.Clover;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Card;
            if (other == null)
                return 1;
            if (other.Label > this.Label)
                return -1;
            if (other.Label < this.Label)
                return 1;
            return 0;
        }

        public override string ToString()
        {
            var result = string.Empty;
            switch (this.Label)
            {
                case CardLabel.Two:
                    result = "2";
                    break;
                case CardLabel.Three:
                    result = "3";
                    break;
                case CardLabel.Four:
                    result = "4";
                    break;
                case CardLabel.Five:
                    result = "5";
                    break;
                case CardLabel.Six:
                    result = "6";
                    break;
                case CardLabel.Seven:
                    result = "7";
                    break;
                case CardLabel.Eight:
                    result = "8";
                    break;
                case CardLabel.Nine:
                    result = "9";
                    break;
                case CardLabel.Ten:
                    result = "T";
                    break;
                case CardLabel.Jack:
                    result = "J";
                    break;
                case CardLabel.Queen:
                    result = "Q";
                    break;
                case CardLabel.King:
                    result = "K";
                    break;
                case CardLabel.Ace:
                    result = "A";
                    break;
            }
            switch (this.Color)
            {
                case CardColor.Clover:
                    result += "C";
                    break;
                case CardColor.Diamond:
                    result += "D";
                    break;
                case CardColor.Heart:
                    result += "H";
                    break;
               case CardColor.Spade:
                    result += "S";
                    break;
            }

            return result;
        }
    }
}