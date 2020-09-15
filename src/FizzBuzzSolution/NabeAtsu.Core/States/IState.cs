using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    /// <summary>
    /// 状態インタフェース
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 有効かどうか
        /// </summary>
        /// <remarks>
        /// 現状常にTrueなので、無意味な機能です。
        /// </remarks>
        public bool Enabled { get; }

        /// <summary>
        /// 内包する状態
        /// </summary>
        public IEnumerable<IState> SubStates { get; }

        /// <summary>
        /// 条件に当てはまるかどうか
        /// </summary>
        /// <param name="value">数値</param>
        public bool IsApplied(BigInteger value);

        /// <summary>
        /// 数値を文字列に変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>変換結果</returns>
        public Result Convert(BigInteger value);
    }
}
