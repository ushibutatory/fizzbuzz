using System.Numerics;

namespace NabeAtsu.Core.States.Lv1.Dog
{
    public class DogState : BaseState
    {
        private DogState() { }

        public override int Level => 1;

        public override bool IsSatisfied(BigInteger value)
        {
            return value % 5 == 0;
        }

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = "わん！U^ｪ^U",
            }.Build();

        public class Builder : BaseStateBuilder
        {
            public override IState Build()
                => new DogState();
        }
    }
}
