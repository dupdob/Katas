using System;
using System.Text;
using NFluent;
using NUnit.Framework;

namespace PokerHandKata
{
    [TestFixture]
    public class BuildDiamond
    {
        [Test]
        public void ShouldReturnEmptyStringFor0()
        {
            Check.That(ConstructDiamond(0)).IsEmpty();
        }

        [Test]
        public void ShouldReturnSimpleAFor1()
        {
            Check.That(ConstructDiamond(1)).IsEqualTo("A");
        }

        [Test]
        public void ShouldReturnCorrectDiamondFor2()
        {
            Check.That(ConstructDiamond(2)).IsEqualTo(" A\n" +
                                                      "B B\n" +
                                                      " A");
        }

        [Test]
        public void ShouldReturnCorrectDiamondFor3()
        {
            Check.That(ConstructDiamond(3)).IsEqualTo("  A\n" +
                                                      " B B\n" +
                                                      "C   C\n"+
                                                      " B B\n" +
                                                      "  A");
        }

        private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string GenerateDiamondLine(int x)
        {
            if (x == 0)
                return string.Empty;
            else
            {
                var symbol = Alphabet[x-1];
                if (x == 1)
                    return new string(symbol, 1);
                else
                    return symbol + new string(' ', 1+ (x - 2)*2) + symbol;
            }
        }

        private static string ConstructDiamond(int size)
        {
            if (size == 0)
            {
                return string.Empty;
            }
            else if (size == 1)
            {
                return GenerateDiamondLine(1);
            }
            else if (size >=2)
            {
                var result = new StringBuilder();
                for (var i = 1; i <= size; i++)
                {
                    result.Append(new string(' ', size - i));
                    result.Append(GenerateDiamondLine(i));
                    result.Append('\n');
                }
                for (var i = size-1; i > 0; i--)
                {
                    result.Append(new string(' ', size - i));
                    result.Append(GenerateDiamondLine(i));
                    if (i>1)
                        result.Append('\n');
                }
                return result.ToString();
            }
            throw new NotImplementedException();
        }

    }
}
