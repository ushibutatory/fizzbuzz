using Xunit;

namespace NabeAtsu.Core.Tests
{
    public class ConstsTest
    {
        [Theory]
        [InlineData(0, Consts.DigitPartType.Unknown)]
        [InlineData(1, Consts.DigitPartType.One)]
        [InlineData(2, Consts.DigitPartType.Ten)]
        [InlineData(3, Consts.DigitPartType.Hundred)]
        [InlineData(4, Consts.DigitPartType.Thousand)]
        [InlineData(5, Consts.DigitPartType.One)]
        [InlineData(6, Consts.DigitPartType.Ten)]
        [InlineData(7, Consts.DigitPartType.Hundred)]
        [InlineData(8, Consts.DigitPartType.Thousand)]
        [InlineData(9, Consts.DigitPartType.One)]
        public void GetDigitPart(int digit, Consts.DigitPartType expected)
        {
            Assert.Equal(expected, Consts.GetDigitPart(digit));
        }

        [Theory]
        [InlineData(0, Consts.DigitScaleType.Unknown)]
        [InlineData(1, Consts.DigitScaleType.一)] // 1
        [InlineData(2, Consts.DigitScaleType.一)] // 10
        [InlineData(3, Consts.DigitScaleType.一)] // 100
        [InlineData(4, Consts.DigitScaleType.一)] // 1000
        [InlineData(5, Consts.DigitScaleType.万)] // 10,000
        [InlineData(6, Consts.DigitScaleType.万)] // 100,000
        [InlineData(7, Consts.DigitScaleType.万)] // 1,000,000
        [InlineData(8, Consts.DigitScaleType.万)] // 10,000,000
        [InlineData(9, Consts.DigitScaleType.億)] // 100,000,000
        public void GetDigitScale(int digit, Consts.DigitScaleType expected)
        {
            Assert.Equal(expected, Consts.GetDigitScale(digit));
        }
    }
}
