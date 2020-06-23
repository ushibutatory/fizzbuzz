using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv1
{
    public class GoodFeelingState : BaseState
    {
        public override bool IsApplied(BigInteger value)
            => value % 8 == 0;

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = value.ToString() + "(*´ω｀*)",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new[] { new GoodFeelingState() };
    }
}
