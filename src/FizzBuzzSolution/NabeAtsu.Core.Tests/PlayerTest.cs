using NabeAtsu.Core.States;
using System.Linq;
using Xunit;

namespace NabeAtsu.Core.Tests
{
    public class PlayerTest
    {
        private static class State
        {
            public static IState Default => new States.Lv0.Default.DefaultState.Builder()
                .Build();

            public static IState Fool => new States.Lv1.Fool.FoolState.Builder()
                .Build();

            public static IState Dog => new States.Lv1.Dog.DogState.Builder()
                .Build();

            public static IState FoolDog => new States.Lv2.FoolDog.FoolDogState.Builder()
                .Build();
        }

        [Fact]
        public void PlainPlayer()
        {
            var player = new Player.Builder()
                .AddState(State.Default)
                .Build();

            var results = Enumerable.Range(1, 100).Select(n => player.Answer(n));

            Assert.Empty(results.Where(result => result.OriginalValue.ToString() != result.ConvertedText));
        }

        public static TheoryData<int, IState> JudgeStatePatterns => new TheoryData<int, IState>
        {
            { 1, State.Default },
            { 2, State.Default },
            { 3, State.Fool },
            { 4, State.Default },
            { 5, State.Dog },
            { 6, State.Fool },
            { 7, State.Default },
            { 8, State.Default },
            { 9, State.Fool },
            { 10, State.Dog },
            { 11, State.Default },
            { 12, State.Fool },
            { 13, State.Fool },
            { 14, State.Default },
            { 15, State.FoolDog },
        };

        [Theory]
        [MemberData(nameof(JudgeStatePatterns))]
        public void JudgeState(int n, IState expected)
        {
            var player = new Player.Builder()
                .AutoBuild();

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
                .AutoBuild();

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
                .AutoBuild();

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
                .AutoBuild();

            var actual = player.Answer(n);
            Assert.Equal(expected, actual.ConvertedText);
        }
    }
}
