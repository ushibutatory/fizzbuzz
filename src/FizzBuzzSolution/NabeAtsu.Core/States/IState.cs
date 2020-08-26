using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    public interface IState
    {
        public bool Enabled { get; }

        public IEnumerable<IState> SubStates { get; }

        public bool IsApplied(BigInteger value);

        public Result Convert(BigInteger value);
    }
}
