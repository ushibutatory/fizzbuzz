using NabeAtsu.Core.States;
using NabeAtsu.Core.States.Lv0;
using NabeAtsu.Core.States.Lv1;
using NabeAtsu.Core.States.Lv2;
using System.Collections.Generic;
using Xunit;

namespace NabeAtsu.Core.Tests
{
    public class PlayerTest
    {
        private static IState _Default => new DefaultState();
        private static IState _Fool => new FoolState();
        private static IState _Dog => new DogState();
        private static IState _FoolDog => new FoolDogState();

        public static IEnumerable<object[]> NabeAtsuPatterns() => new[]
            {
                new object[]{ 1, _Default },
                new object[]{ 2, _Default },
                new object[]{ 3, _Fool },
                new object[]{ 4, _Default },
                new object[]{ 5, _Dog },
                new object[]{ 6, _Fool },
                new object[]{ 7, _Default },
                new object[]{ 8, _Default },
                new object[]{ 9, _Fool },
                new object[]{ 10, _Dog },
                new object[]{ 11, _Default },
                new object[]{ 12, _Fool },
                new object[]{ 13, _Fool },
                new object[]{ 14, _Default },
                new object[]{ 15, _FoolDog },
            };

        [Theory]
        [MemberData(nameof(NabeAtsuPatterns))]
        public void NabeAtsu(int n, IState useState)
        {
            var player = new Player();
            var result = player.Answer(n);
            // TODO: もうちょっといい判定方法ありそう……
            Assert.True(useState.GetType() == result.UsingState.GetType());
        }

        [Theory]
        [InlineData(63, "ろくじゅうさぁん")]
        [InlineData(83, "はちじゅうさぁん")]
        [InlineData(103, "ひゃくさぁん")]
        [InlineData(303, "さんびゃくさぁん")]
        [InlineData(603, "ろっぴゃくさぁん")]
        [InlineData(803, "はっぴゃくさぁん")]
        [InlineData(1003, "せんさぁん")]
        [InlineData(3003, "さんぜんさぁん")]
        [InlineData(10003, "いちまんさぁん")]
        [InlineData(100003, "じゅうまんさぁん")]
        public void KanaPatterns(int n, string expected)
        {
            var player = new Player();
            var result = player.Answer(n);
            Assert.Equal(expected, result.ConvertedText);
        }
    }
}
