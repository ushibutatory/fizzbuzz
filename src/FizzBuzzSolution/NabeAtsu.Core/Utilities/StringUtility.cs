using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NabeAtsu.Core.Utilities
{
    /// <summary>
    /// 文字列ユーティリティクラス
    /// </summary>
    public static class StringUtility
    {
        /// <summary>
        /// 文字列をBigIntegerに変換します。
        /// 変換できない場合はnullを返します。
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>BigInteger値</returns>
        public static BigInteger? ToBigInteger(string value)
            => BigInteger.TryParse(value, out BigInteger result)
                ? (BigInteger?)result
                : null;

        /// <summary>
        /// 文字列を列挙型に変換します。
        /// 変換できない場合はnullを返します。
        /// </summary>
        /// <typeparam name="T">列挙型</typeparam>
        /// <param name="value">文字列</param>
        /// <returns>列挙型値</returns>
        public static T? ToEnum<T>(string value) where T : struct
            => Enum.TryParse(value, out T result)
                ? (T?)result
                : null;

        /// <summary>
        /// 文字列を分割する方向
        /// </summary>
        public enum SplitDirection
        {
            /// <summary>
            /// 文字列の先頭から数える
            /// </summary>
            Forward,
            /// <summary>
            /// 文字列の後ろから数える
            /// </summary>
            Back
        }

        /// <summary>
        /// 文字列を指定した長さで分割します。
        /// </summary>
        /// <param name="text">分割する文字列</param>
        /// <param name="length">分割する長さ</param>
        /// <param name="direction">分割する方向</param>
        /// <returns>分割した文字列リスト</returns>
        public static List<string> SplitLength(string text, int length, SplitDirection direction = SplitDirection.Forward)
        {
            var result = new List<string>();

            var block = new StringBuilder();

            switch (direction)
            {
                case SplitDirection.Forward:
                    // 前から数える
                    for (var i = 0; i < text.Length; i++)
                    {
                        block.Append(text[i]);
                        if (block.Length >= length)
                        {
                            result.Add(block.ToString());
                            block.Clear();
                        }
                    }
                    if (block.Length > 0)
                    {
                        // 残りがあれば最後に追加
                        result.Add(block.ToString());
                    }
                    break;

                case SplitDirection.Back:
                    // 後ろから数える
                    for (var i = text.Length - 1; i >= 0; i--)
                    {
                        block.Insert(0, text[i]);
                        if (block.Length >= length)
                        {
                            result.Insert(0, block.ToString());
                            block.Clear();
                        }
                    }
                    if (block.Length > 0)
                    {
                        // 残りを先頭に追加
                        result.Insert(0, block.ToString());
                    }
                    break;
            }

            return result;
        }
    }
}
