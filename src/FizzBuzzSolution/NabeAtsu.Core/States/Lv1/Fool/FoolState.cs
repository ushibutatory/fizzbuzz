using NabeAtsu.Core.Utilities;
using System;
using System.Numerics;
using System.Text;

namespace NabeAtsu.Core.States.Lv1.Fool
{
    public class FoolState : BaseState
    {
        private readonly FoolConverter _converter;

        private FoolState(Builder builder)
        {
            _converter = builder.FoolConverter;
        }

        public override int Level => 1;

        public override bool IsSatisfied(BigInteger value)
        {
            return (value % 3 == 0) || value.ToString().Contains("3");
        }

        public override Result Convert(BigInteger value)
        {
            var text = new StringBuilder();

            // 何桁目か（大きい桁から数える）
            var digit = value.ToString().Length;

            // 小さい桁から4桁ごとに分割する
            foreach (var block in StringUtility.SplitLength(value.ToString(), 4, StringUtility.Direction.BackFromEnd))
            {
                if (int.Parse(block) == 0)
                {
                    // ブロックが0のみの場合は、何も出力しない
                    digit -= block.Length;
                }
                else
                {
                    // 1文字ずつ変換
                    for (int i = 0; i < block.Length; i++)
                    {
                        // 1桁分の数字を取得
                        var number = int.Parse(block[i].ToString());

                        // 次の数字を取得（促音かどうかなどの判定のため）
                        var nextChar = (block.Length > i + 1) ? (char?)block[i + 1] : null;
                        int? nextNumber = int.TryParse(nextChar.ToString(), out var v) ? (int?)v : null;

                        // 数を変換
                        text.Append(_converter.ToFoolNumber(value, number, nextNumber, digit));

                        // 桁を変換
                        text.Append(_converter.ToFoolDigit(value, number, nextNumber, digit));

                        digit--;
                    }
                }
            }

            return new Result.Builder
            {
                UsingState = this,
                OriginalValue = value,
                ConvertedText = text.ToString()
            }.Build();
        }

        public class Builder : BaseStateBuilder
        {
            private readonly FoolConverter.Builder _converterBuilder = new FoolConverter.Builder();

            public Builder Setup(Action<FoolConverter.Builder> setup)
            {
                setup(_converterBuilder);
                return this;
            }

            public FoolConverter FoolConverter => _converterBuilder.Build();

            public override IState Build()
                => new FoolState(this);
        }
    }
}
