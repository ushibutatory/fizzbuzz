using NabeAtsu.Core.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv3
{
    public class GoodFeelingFoolDogState : BaseDuplicateState
    {
        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = "わふーーーーーん！！！U*´ω｀*U",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new IState[] {
                new FoolState(),
                new DogState(),
                new GoodFeelingState(),
            };
    }
}
