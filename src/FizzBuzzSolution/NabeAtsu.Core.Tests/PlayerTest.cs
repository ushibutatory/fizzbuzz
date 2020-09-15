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

        public static TheoryData<int, IState> JudgeStatePatterns => new TheoryData<int, IState>
        {
            { 1, _Default },
            { 2, _Default },
            { 3, _Fool },
            { 4, _Default },
            { 5, _Dog },
            { 6, _Fool },
            { 7, _Default },
            { 8, _Default },
            { 9, _Fool },
            { 10, _Dog },
            { 11, _Default },
            { 12, _Fool },
            { 13, _Fool },
            { 14, _Default },
            { 15, _FoolDog },
        };

        [Theory]
        [MemberData(nameof(JudgeStatePatterns))]
        public void JudgeState(int n, IState expected)
        {
            var player = new Player.Builder()
                .AutoSetup()
                .Build();

            var actual = player.JudgeState(n);
            Assert.True(expected.GetType() == actual.GetType());
        }

        public static TheoryData<int, string> ConvertText_FoolPatterns => new TheoryData<int, string>
        {
            { 63, "ろくじゅうさぁん" },
            { 63, "ろくじゅうさぁん" },
            { 83, "はちじゅうさぁん" },
            { 103, "ひゃくさぁん" },
            { 303, "さんびゃくさぁん" },
            { 603, "ろっぴゃくさぁん" },
            { 803, "はっぴゃくさぁん" },
            { 1003, "せんさぁん" },
            { 3003, "さんぜんさぁん" },
            { 10003, "いちまんさぁん" },
            { 100003, "じゅうまんさぁん" },
        };

        [Theory]
        [MemberData(nameof(ConvertText_FoolPatterns))]
        public void ConvertText_Fool(int n, string expected)
        {
            var player = new Player.Builder()
                .AutoSetup()
                .Build();

            var actual = player.Answer(n);
            Assert.Equal(expected, actual.ConvertedText);
        }

        public static TheoryData<int, string> ConvertText_DogPatterns => new TheoryData<int, string>
        {
            { 5, "わん！U^ｪ^U" },
            { 10, "わん！U^ｪ^U" },
        };

        [Theory]
        [MemberData(nameof(ConvertText_DogPatterns))]
        public void ConvertText_Dog(int n, string expected)
        {
            var player = new Player.Builder()
                .AutoSetup()
                .Build();

            var actual = player.Answer(n);
            Assert.Equal(expected, actual.ConvertedText);
        }

        public static TheoryData<int, string> ConvertText_FoolDogPatterns => new TheoryData<int, string>
        {
            { 15, "じゅうごゎぉーん！" },
            { 30, "さんじゅゎぉーん！" },
            { 150, "ひゃくごじゅゎぉーん！" },
            { 300, "さんびゃくゎぉーん！" },
        };

        [Theory]
        [MemberData(nameof(ConvertText_FoolDogPatterns))]
        public void ConvertText_FoolDog(int n, string expected)
        {
            var player = new Player.Builder()
                .AutoSetup()
                .Build();

            var actual = player.Answer(n);
            Assert.Equal(expected, actual.ConvertedText);
        }
    }
}
