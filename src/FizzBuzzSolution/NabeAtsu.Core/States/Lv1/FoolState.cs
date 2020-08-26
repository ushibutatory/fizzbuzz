using NabeAtsu.Core.Utilities;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NabeAtsu.Core.States.Lv1
{
    public class FoolState : BaseState
    {
        /// <summary>
        /// 単位の区切り種別
        /// </summary>
        /// <remarks>
        /// 4で割った余り
        /// </remarks>
        private enum DigitPartType
        {
            One = 1,
            Ten = 2,
            Hundred = 3,
            Thousand = 0
        }

        /// <summary>
        /// 単位の段階種別
        /// </summary>
        /// <remarks>
        /// 4で割った商
        /// </remarks>
        private enum DigitScaleType
        {
            一 = 0,
            万 = 1,
            億 = 2,
            兆 = 3,
            京 = 4,
            垓 = 5,
            抒 = 6,
            穣 = 7,
            溝 = 8,
            澗 = 9,
            正 = 10,
            載 = 11,
            極 = 12,
            恒河沙 = 13,
            阿僧祇 = 14,
            那由他 = 15,
            不可思議 = 16,
            無量大数 = 17
        }

        public override bool IsApplied(BigInteger value)
            => (value % 3 == 0) || value.ToString().Contains("3");

        public override Result Convert(BigInteger value)
        {
            var text = new StringBuilder();

            // 何桁目か（大きい桁から数える）
            var digit = value.ToString().Length;

            // 小さい桁から4桁ごとに分割する
            foreach (var block in StringUtility.SplitLength(value.ToString(), 4, StringUtility.SplitDirection.BackFromEnd))
            {
                if (int.Parse(block) == 0)
                {
                    // ブロックが0のみの場合は、何も出力しない
                    digit -= block.Length;
                }
                else
                {
                    // 1文字ずつ変換
                    foreach (var @char in block)
                    {
                        // 1桁分の数字を取得
                        var number = int.Parse(@char.ToString());

                        // 数を変換
                        text.Append(_ToFoolNumber(number, digit));

                        // 桁を変換
                        text.Append(_ToFoolDigit(number, digit));

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

        protected override IEnumerable<IState> _CreateSubStates()
            => new[] { new FoolState() };

        private string _ToFoolNumber(int number, int digit)
        {
            var result = "";
            if (digit == 1)
            {
                // 1の位
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
            }
            else
            {
                // 単位の区切りを取得
                var digitPart = _GetDigitPart(digit);

                switch (number)
                {
                    case 0: return "";
                    case 1:
                        switch (digitPart)
                        {
                            case DigitPartType.One:
                                switch (_GetDigitScale(digit))
                                {
                                    case DigitScaleType.兆:
                                    case DigitScaleType.京:
                                    case DigitScaleType.澗:
                                    case DigitScaleType.正:
                                    case DigitScaleType.載:
                                        return "いっ";
                                    default:
                                        return "いち";
                                }

                            default:
                                return "";
                        }
                    case 2: return "に";
                    case 3: return "さん";
                    case 4: return "よん";
                    case 5: return "ご";
                    case 6:
                        return digitPart switch
                        {
                            DigitPartType.Hundred => "ろっ",
                            _ => "ろく",
                        };
                    case 7: return "なな";
                    case 8:
                        switch (digitPart)
                        {
                            case DigitPartType.Hundred:
                            case DigitPartType.Thousand:
                                return "はっ";
                            default:
                                return "はち";
                        }
                    case 9: return "きゅう";
                }
            }
            return result;
        }

        private string _ToFoolDigit(int number, int digit)
        {
            var result = "";
            switch (_GetDigitPart(digit))
            {
                case DigitPartType.One:
                    return (_GetDigitScale(digit)) switch
                    {
                        DigitScaleType.一 => "",
                        DigitScaleType.万 => "まん",
                        DigitScaleType.億 => "おく",
                        DigitScaleType.兆 => "ちょー",
                        DigitScaleType.京 => "けぇー",
                        DigitScaleType.垓 => "がぃ",
                        DigitScaleType.抒 => "じょぉ",
                        DigitScaleType.穣 => "じょぅ",
                        DigitScaleType.溝 => "こお",
                        DigitScaleType.澗 => "かんん",
                        DigitScaleType.正 => "せーぃ",
                        DigitScaleType.載 => "さぁい",
                        DigitScaleType.極 => "ごく",
                        DigitScaleType.恒河沙 => "ごーがしゃー",
                        DigitScaleType.阿僧祇 => "あそーぎぃ",
                        DigitScaleType.那由他 => "なゆたぁ",
                        DigitScaleType.不可思議 => "ふかしぎぃー",
                        DigitScaleType.無量大数 => "むりょーたいすー",
                        _ => "",
                    };

                case DigitPartType.Ten:
                    switch (number)
                    {
                        case 0:
                            return "";
                        default:
                            switch (_GetDigitScale(digit))
                            {
                                case DigitScaleType.兆:
                                case DigitScaleType.京:
                                case DigitScaleType.溝:
                                case DigitScaleType.澗:
                                case DigitScaleType.正:
                                case DigitScaleType.載:
                                    return "じゅっ";
                                default:
                                    return "じゅう";
                            }
                    }

                case DigitPartType.Hundred:
                    switch (number)
                    {
                        case 0:
                            return "";
                        case 3:
                            return "びゃく";
                        case 6:
                        case 8:
                            return "ぴゃく";
                        default:
                            return "ひゃく";
                    }

                case DigitPartType.Thousand:
                    switch (number)
                    {
                        case 0:
                            return "";
                        case 3:
                            return "ぜん";
                        default:
                            return "せん";
                    }

            }
            return result;
        }

        private DigitPartType? _GetDigitPart(int digit)
            => StringUtility.ToEnum<DigitPartType>((digit % 4).ToString());

        private DigitScaleType? _GetDigitScale(int digit)
            => StringUtility.ToEnum<DigitScaleType>((digit / 4).ToString());
    }
}
