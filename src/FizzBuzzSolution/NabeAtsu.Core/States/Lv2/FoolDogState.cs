using NabeAtsu.Core.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2
{
    public class FoolDogState : BaseDuplicateState
    {
        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = "わおーーーーーーーん！U゜ｪ。U",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new IState[] {
                new FoolState(),
                new DogState(),
            };
    }
}
