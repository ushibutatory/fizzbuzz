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
        /// 有効かどうかを取得します。
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 子状態リストを取得します。
        /// </summary>
        IEnumerable<IState> SubStates { get; }

        /// <summary>
        /// 指定された数値が状態の条件に当てはまるかどうかを取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態の条件に当てはまるかどうか</returns>
        bool IsApplied(BigInteger value);

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        Result Convert(BigInteger value);
    }
}
