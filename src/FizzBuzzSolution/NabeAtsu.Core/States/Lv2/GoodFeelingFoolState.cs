using NabeAtsu.Core.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2
{
    public class GoodFeelingFoolState : BaseDuplicateState
    {
        private readonly IState _fool = new FoolState();

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = _fool.Convert(value).ConvertedText + "(*´ω｀*)",
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => new IState[] {
                new FoolState(),
                new GoodFeelingState(),
            };
    }
}
