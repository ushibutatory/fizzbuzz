using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NabeAtsu.Core.Utilities
{
    public static class StringUtility
    {
        public static BigInteger? ToBigInteger(string value)
            => BigInteger.TryParse(value, out BigInteger result)
                ? (BigInteger?)result
                : null;

        public static T? ToEnum<T>(string value) where T : struct
            => Enum.TryParse(value, out T result)
                ? (T?)result
                : null;

        public enum SplitDirection
        {
            ForwardFromStart,
            BackFromEnd
        }

        public static List<string> SplitLength(string text, int length, SplitDirection direction = SplitDirection.ForwardFromStart)
        {
            var result = new List<string>();

            var block = new StringBuilder();

            switch (direction)
            {
                case SplitDirection.ForwardFromStart:
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

                case SplitDirection.BackFromEnd:
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
