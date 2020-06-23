using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    public class StateNotFoundException : Exception
    {
        public BigInteger Value { get; }

        public IEnumerable<IState> States { get; }

        public StateNotFoundException(IEnumerable<IState> states, BigInteger value)
            : base($"当てはまる状態が見つかりませんでした。[{value}]")
        {
            States = states;
            Value = value;
        }
    }
}
