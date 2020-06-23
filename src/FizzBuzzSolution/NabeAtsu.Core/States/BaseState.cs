using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    public abstract class BaseState : IState
    {
        private IEnumerable<IState> _subStates = null;

        public bool Enabled => true;

        public IEnumerable<IState> SubStates
        {
            get
            {
                if (_subStates == null)
                {
                    // 初回生成
                    _subStates = _CreateSubStates();
                }
                return _subStates;
            }
        }

        public abstract bool IsApplied(BigInteger value);

        public abstract Result Convert(BigInteger value);

        protected abstract IEnumerable<IState> _CreateSubStates();
    }
}
