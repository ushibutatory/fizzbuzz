using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv0
{
    public class DefaultState : BaseState
    {
        public override bool IsApplied(BigInteger value)
            // 常に
            => true;

        public override Result Convert(BigInteger value)
            => new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = value.ToString(),
            }.Build();

        protected override IEnumerable<IState> _CreateSubStates()
            => Enumerable.Empty<IState>();
    }
}
