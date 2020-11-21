using NabeAtsu.Core.States;

namespace NabeAtsu.Core
{
    public abstract class BaseStateBuilder : IStateBuilder
    {
        public abstract IState Build();
    }
}
