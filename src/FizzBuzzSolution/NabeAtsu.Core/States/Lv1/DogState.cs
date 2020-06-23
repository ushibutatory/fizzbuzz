using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv1
{
    public class DogState : BaseState
    {
        public override bool IsApplied(BigInteger value)
            => value % 5 == 0;

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = "わん！U^ｪ^U",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new[] { new DogState() };
    }
}
