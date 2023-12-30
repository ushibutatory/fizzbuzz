using System;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv1.Fool
{
    /// <summary>
    /// アホ変換器
    /// </summary>
    public class FoolConverter
    {
        public delegate string ConvertNumberDelegate(BigInteger value, int number, int digit);

        public delegate string ConvertDigitPartDelegate(BigInteger value, int number, int? nextNumber, int digit);

        private FoolConverter(Builder builder)
        {
            ConvertFoolNumber = builder.ConvertFoolNumber;
            ConvertDigitPart_One = builder.ConvertDigitPart_One;
            ConvertDigitPart_Ten = builder.ConvertDigitPart_Ten;
            ConvertDigitPart_Hundred = builder.ConvertDigitPart_Hundred;
            ConvertDigitPart_Thousand = builder.ConvertDigitPart_Thousand;
        }

        /// <summary>
        /// 1～9の数値をアホ変換します。
        /// </summary>
        /// <param name="value">元の数値</param>
        /// <param name="number">変換対象の数値</param>
        /// <param name="nextNumber">変換対象の次の桁の数値</param>
        /// <param name="digit">何桁目か</param>
        /// <returns></returns>
        public string ToFoolNumber(BigInteger value, int number, int? nextNumber, int digit)
        {
            var result = "";
            if (digit == 1)
            {
                // 1の位
                return ConvertFoolNumber(value, number, digit);
            }
            else
            {
                // 単位の区切りを取得
                var digitPart = Consts.GetDigitPart(digit);

                switch (number)
                {
                    case 0: return "";
                    case 1:
                        return digitPart switch
                        {
                            Consts.DigitPartType.One => _IsSokuon(digit) ? "いっ" : "いち",
                            _ => "",
                        };
                    case 2: return "に";
                    case 3: return "さん";
                    case 4: return "よん";
                    case 5: return "ご";
                    case 6:
                        return digitPart switch
                        {
                            Consts.DigitPartType.Hundred => "ろっ",
                            _ => "ろく",
                        };
                    case 7: return "なな";
                    case 8:
                        switch (digitPart)
                        {
                            case Consts.DigitPartType.Hundred:
                            case Consts.DigitPartType.Thousand:
                                return "はっ";
                            default:
                                return "はち";
                        }
                    case 9: return "きゅう";
                }
            }
            return result;
        }

        /// <summary>
        /// 桁をアホ変換します。
        /// </summary>
        /// <param name="value">元の数値</param>
        /// <param name="number">変換対象の数値</param>
        /// <param name="nextNumber">変換対象の次の数値</param>
        /// <param name="digit">何桁目か</param>
        /// <returns></returns>
        public string ToFoolDigit(BigInteger value, int number, int? nextNumber, int digit) => (Consts.GetDigitPart(digit)) switch
        {
            Consts.DigitPartType.One => ConvertDigitPart_One(value, number, nextNumber, digit),
            Consts.DigitPartType.Ten => ConvertDigitPart_Ten(value, number, nextNumber, digit),
            Consts.DigitPartType.Hundred => ConvertDigitPart_Hundred(value, number, nextNumber, digit),
            Consts.DigitPartType.Thousand => ConvertDigitPart_Thousand(value, number, nextNumber, digit),
            _ => "",
        };

        private readonly ConvertNumberDelegate ConvertFoolNumber;
        private readonly ConvertDigitPartDelegate ConvertDigitPart_One;
        private readonly ConvertDigitPartDelegate ConvertDigitPart_Ten;
        private readonly ConvertDigitPartDelegate ConvertDigitPart_Hundred;
        private readonly ConvertDigitPartDelegate ConvertDigitPart_Thousand;

        /// <summary>
        /// 単位が促音でつながるかどうかを返します。
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private static bool _IsSokuon(int digit)
        {
            switch (Consts.GetDigitScale(digit))
            {
                case Consts.DigitScaleType.兆:
                case Consts.DigitScaleType.京:
                case Consts.DigitScaleType.溝:
                case Consts.DigitScaleType.澗:
                case Consts.DigitScaleType.正:
                case Consts.DigitScaleType.載:
                    return true;
                default:
                    return false;
            }
        }

        public class Builder
        {
            public ConvertNumberDelegate ConvertFoolNumber = (value, number, digit) =>
            {
                return number switch
                {
                    0 => "",
                    1 => "いち",
                    2 => "にぃ",
                    3 => "さぁん",
                    4 => "よぉん",
                    5 => "ごぉ",
                    6 => "ろぉく",
                    7 => "ななぁ",
                    8 => "はぁち",
                    9 => "きゅう",
                    _ => "",
                };
            };

            public ConvertDigitPartDelegate ConvertDigitPart_One = (value, number, nextNumber, digit) =>
            {
                return (Consts.GetDigitScale(digit)) switch
                {
                    Consts.DigitScaleType.一 => "",
                    Consts.DigitScaleType.万 => "まん",
                    Consts.DigitScaleType.億 => "おく",
                    Consts.DigitScaleType.兆 => "ちょー",
                    Consts.DigitScaleType.京 => "けぇー",
                    Consts.DigitScaleType.垓 => "がぃ",
                    Consts.DigitScaleType.抒 => "じょぉ",
                    Consts.DigitScaleType.穣 => "じょぅ",
                    Consts.DigitScaleType.溝 => "こお",
                    Consts.DigitScaleType.澗 => "かんん",
                    Consts.DigitScaleType.正 => "せーぃ",
                    Consts.DigitScaleType.載 => "さぁい",
                    Consts.DigitScaleType.極 => "ごく",
                    Consts.DigitScaleType.恒河沙 => "ごーがしゃー",
                    Consts.DigitScaleType.阿僧祇 => "あそーぎぃ",
                    Consts.DigitScaleType.那由他 => "なゆたぁ",
                    Consts.DigitScaleType.不可思議 => "ふかしぎぃー",
                    Consts.DigitScaleType.無量大数 => "むりょーたいすー",
                    _ => "",
                };
            };

            public ConvertDigitPartDelegate ConvertDigitPart_Ten = (value, number, nextNumber, digit) =>
            {
                return number switch
                {
                    0 => "",
                    _ => _IsSokuon(digit) ? "じゅっ" : "じゅう",
                };
            };

            public ConvertDigitPartDelegate ConvertDigitPart_Hundred = (value, number, nextNumber, digit) =>
            {
                switch (number)
                {
                    case 0:
                        return "";
                    case 3:
                        return _IsSokuon(digit) ? "びゃっ" : "びゃく";
                    case 6:
                    case 8:
                        return _IsSokuon(digit) ? "ぴゃっ" : "ぴゃく";
                    default:
                        return _IsSokuon(digit) ? "ひゃっ" : "ひゃく";
                };
            };

            public ConvertDigitPartDelegate ConvertDigitPart_Thousand = (value, number, nextNumber, digit) =>
            {
                return number switch
                {
                    0 => "",
                    3 => "ぜん",
                    _ => "せん",
                };
            };

            public FoolConverter Build()
                => new FoolConverter(this);
        }
    }
}
