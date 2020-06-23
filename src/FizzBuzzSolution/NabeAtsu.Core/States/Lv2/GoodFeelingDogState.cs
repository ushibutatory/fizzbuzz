using NabeAtsu.Core.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2
{
    public class GoodFeelingDogState : BaseDuplicateState
    {
        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = "わふんU*´ω｀*U",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new IState[] {
                new DogState(),
                new GoodFeelingState(),
            };
    }
}
