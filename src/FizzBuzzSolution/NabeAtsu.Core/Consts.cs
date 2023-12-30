using NabeAtsu.Core.Utilities;

namespace NabeAtsu.Core
{
    public static class Consts
    {
        /// <summary>
        /// 単位の区切り種別
        /// </summary>
        /// <remarks>
        /// 日本語では4桁ごとに単位が上がっていく。
        /// 数字列を4桁ごとで割った余り文字数で判別する。
        /// -     "1" → 1（一）
        /// -    "10" → 2（十）
        /// -   "100" → 3（百）
        /// -  "1000" → 0（千）
        /// - "10000" → 1（次の単位）
        /// - ...
        /// </remarks>
        public enum DigitPartType
        {
            Unknown = -1,
            One = 1,
            Ten = 2,
            Hundred = 3,
            Thousand = 0,
        }

        /// <summary>
        /// 単位区切りを取得します。
        /// </summary>
        /// <param name="digit">桁数</param>
        /// <returns>区切り種別</returns>
        /// <remarks>
        /// 例: 10桁の数値（digit = 10）の場合 ...
        ///     xx億なので DigitPartType.Ten を返す
        ///     <br/>
        /// 例: 11桁の数値（digit = 11）の場合 ...
        ///     xxx億なので DigitPartType.Hundred を返す
        /// </remarks>
        public static DigitPartType GetDigitPart(int digit)
            => digit > 0
            ? StringUtility.ToEnum<DigitPartType>((digit % 4).ToString()) ?? DigitPartType.Unknown
            : DigitPartType.Unknown;

        /// <summary>
        /// 単位種別
        /// </summary>
        public enum DigitScaleType
        {
            Unknown = -1,
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

        /// <summary>
        /// 単位を取得します。
        /// </summary>
        /// <param name="digit">桁数</param>
        /// <returns>単位</returns>
        /// <remarks>
        /// 数字列を4桁ごとで割った商で判別する。
        /// 例: 10桁の数値の場合
        ///  digit = 10
        ///  → 商 2
        ///  → '億' を返す
        /// </remarks>
        public static DigitScaleType GetDigitScale(int digit)
            => digit > 0
            ? StringUtility.ToEnum<DigitScaleType>(((digit - 1) / 4).ToString()) ?? DigitScaleType.Unknown
            : DigitScaleType.Unknown;
    }
}
