using System.Numerics;

namespace NabeAtsu.Core.States.Lv0.Default
{
    public class DefaultState : BaseState
    {
        private DefaultState() { }

        public override int Level => 0;

        // 常に
        public override bool IsSatisfied(BigInteger value) => true;

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = value.ToString(),
            }.Build();

        public class Builder : BaseStateBuilder
        {
            public override IState Build()
                => new DefaultState();
        }
    }
}
