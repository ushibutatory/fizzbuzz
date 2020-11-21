using System.Numerics;

namespace NabeAtsu.Core.States
{
    /// <summary>
    /// 状態基底クラス
    /// </summary>
    public abstract class BaseState : IState
    {
        public bool Enabled => true;

        public abstract int Level { get; }

        public abstract bool IsSatisfied(BigInteger value);

        public abstract Result Convert(BigInteger value);
    }
}
