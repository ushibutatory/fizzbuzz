using NabeAtsu.Core.States;
using System.Numerics;

namespace NabeAtsu.Core
{
    public class Result
    {
        public IState UsingState { get; }

        public BigInteger OriginalValue { get; }

        public string ConvertedText { get; }

        private Result(Builder builder)
        {
            OriginalValue = builder.OriginalValue;
            UsingState = builder.UsingState;
            ConvertedText = builder.ConvertedText;
        }

        public class Builder
        {
            public IState UsingState { get; set; }

            public BigInteger OriginalValue { get; set; }

            public string ConvertedText { get; set; }

            public Result Build()
                => new Result(this);
        }
    }
}
