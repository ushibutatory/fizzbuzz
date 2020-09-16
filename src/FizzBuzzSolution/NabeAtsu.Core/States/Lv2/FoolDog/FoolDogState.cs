using NabeAtsu.Core.States.Lv1.Dog;
using NabeAtsu.Core.States.Lv1.Fool;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2.FoolDog
{
    public class FoolDogState : BaseState
    {
        private FoolDogState() { }

        public override int Level => 2;

        public override bool IsSatisfied(BigInteger value)
        {
            return _Fool.IsSatisfied(value) && _Dog.IsSatisfied(value);
        }

        public override Result Convert(BigInteger value) => new Result.Builder
        {
            UsingState = this,
            OriginalValue = value,
            ConvertedText = _Fool.Convert(value).ConvertedText,
        }.Build();

        private readonly IState _Fool = new FoolState.Builder()
            .Setup((converter) =>
            {
                converter.ConvertFoolNumber = (value, number, digit) => number switch
                {
                    0 => "",
                    1 => "いちゎぉーん！",
                    2 => "にゎぉーん！",
                    3 => "さゎぉーん！",
                    4 => "よゎぉーん！",
                    5 => "ごゎぉーん！",
                    6 => "ろくゎぉーん！",
                    7 => "ななゎぉーん！",
                    8 => "はちゎぉーん！",
                    9 => "きゅゎぉーん！",
                    _ => "",
                };

                converter.ConvertDigitPart_Ten = (value, number, digit) =>
                {
                    switch (number)
                    {
                        case 0:
                            return "";
                        default:
                            switch (Consts.GetDigitScale(digit))
                            {
                                case Consts.DigitScaleType.兆:
                                case Consts.DigitScaleType.京:
                                case Consts.DigitScaleType.溝:
                                case Consts.DigitScaleType.澗:
                                case Consts.DigitScaleType.正:
                                case Consts.DigitScaleType.載:
                                    return "じゅっ";
                                default:
                                    // 現在位置より下位に数値がなければ末尾処理
                                    return "じゅう";
                            }
                    }
                };
            })
            .Build();

        private readonly IState _Dog = new DogState.Builder()
            .Build();

        public class Builder : BaseStateBuilder
        {
            public override IState Build()
                => new FoolDogState();
        }
    }
}
