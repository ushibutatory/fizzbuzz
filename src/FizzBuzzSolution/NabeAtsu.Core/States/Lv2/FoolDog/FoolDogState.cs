using NabeAtsu.Core.States.Lv1.Dog;
using NabeAtsu.Core.States.Lv1.Fool;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2.FoolDog
{
    public class FoolDogState : BaseState
    {
        private FoolDogState() { }

        public override int Level => 2;

        public override bool IsSatisfied(BigInteger value) => _Fool.IsSatisfied(value) && _Dog.IsSatisfied(value);

        public override Result Convert(BigInteger value) => new Result.Builder
        {
            UsingState = this,
            OriginalValue = value,
            ConvertedText = _Fool.Convert(value).ConvertedText,
        }.Build();

        private readonly IState _Fool = new FoolState.Builder()
            .Setup((converter) =>
            {
                var foolConverter = new FoolConverter.Builder();

                static bool IsLast(BigInteger value, int digit)
                {
                    return value.ToString()
                        .Remove(0, value.ToString().Length - digit + 1)
                        .Replace("0", "")
                        .Length == 0;
                }

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

                converter.ConvertDigitPart_One = (value, number, digit) =>
                {
                    return (Consts.GetDigitScale(digit)) switch
                    {
                        Consts.DigitScaleType.一 => "",
                        Consts.DigitScaleType.万 => IsLast(value, digit) ? "まぉーん！" : "まん",
                        Consts.DigitScaleType.億 => IsLast(value, digit) ? "おくぉーん！" : "おく",
                        Consts.DigitScaleType.兆 => IsLast(value, digit) ? "ちょわぉーん！" : "ちょー",
                        Consts.DigitScaleType.京 => IsLast(value, digit) ? "けぉーん！" : "けぇー",
                        Consts.DigitScaleType.垓 => IsLast(value, digit) ? "がゎおーん！" : "がぃ",
                        Consts.DigitScaleType.抒 => IsLast(value, digit) ? "じょぉーん！" : "じょぉ",
                        Consts.DigitScaleType.穣 => IsLast(value, digit) ? "じょぅゎぉーん！" : "じょぅ",
                        Consts.DigitScaleType.溝 => IsLast(value, digit) ? "こぉおーん！" : "こお",
                        Consts.DigitScaleType.澗 => IsLast(value, digit) ? "かぉーーん！" : "かんん",
                        Consts.DigitScaleType.正 => IsLast(value, digit) ? "せぉーん！" : "せーぃ",
                        Consts.DigitScaleType.載 => IsLast(value, digit) ? "さゎぉーん！" : "さぁい",
                        Consts.DigitScaleType.極 => IsLast(value, digit) ? "ごくぉーん！" : "ごく",
                        Consts.DigitScaleType.恒河沙 => IsLast(value, digit) ? "ごがしゃぉーん！" : "ごーがしゃー",
                        Consts.DigitScaleType.阿僧祇 => IsLast(value, digit) ? "あそぎょーん！" : "あそーぎぃ",
                        Consts.DigitScaleType.那由他 => IsLast(value, digit) ? "なゆとぅぉーん！" : "なゆたぁ",
                        Consts.DigitScaleType.不可思議 => IsLast(value, digit) ? "ふかしぎょーーん！" : "ふかしぎぃー",
                        Consts.DigitScaleType.無量大数 => IsLast(value, digit) ? "むりょぉたいすぉーーーーん！" : "むりょーたいすー",
                        _ => "",
                    };
                };

                converter.ConvertDigitPart_Ten = (value, number, digit) =>
                {
                    return number switch
                    {
                        0 => "",
                        _ => Consts.GetDigitScale(digit) switch
                        {
                            Consts.DigitScaleType.一 => IsLast(value, digit) ? "じゅゎぉーん！" : "じゅう",
                            _ => foolConverter.ConvertDigitPart_Ten(value, number, digit),
                        },
                    };
                };

                converter.ConvertDigitPart_Hundred = (value, number, digit) =>
                {
                    var prefix = foolConverter.ConvertDigitPart_Hundred(value, number, digit);

                    return string.IsNullOrEmpty(prefix)
                        ? ""
                        : IsLast(value, digit) && digit < 4 ? $"{prefix}ゎぉーん！" : prefix;
                };

                converter.ConvertDigitPart_Thousand = (value, number, digit) =>
                {
                    return number switch
                    {
                        0 => "",
                        3 => IsLast(value, digit) ? "ぜゎぉーん！" : "ぜん",
                        _ => IsLast(value, digit) ? "せゎぉーん！" : "せん",
                    };
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
