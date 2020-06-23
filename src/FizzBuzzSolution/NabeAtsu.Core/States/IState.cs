using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    public interface IState
    {
        bool Enabled { get; }

        IEnumerable<IState> SubStates { get; }

        bool IsApplied(BigInteger value);

        Result Convert(BigInteger value);
    }
}
