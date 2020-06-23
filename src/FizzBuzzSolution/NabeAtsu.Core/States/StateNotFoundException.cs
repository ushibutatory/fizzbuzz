using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    /// <summary>
    /// 当てはまる状態が見つからない時の例外
    /// </summary>
    public class StateNotFoundException : Exception
    {
        /// <summary>
        /// 対象の数値を取得します。
        /// </summary>
        public BigInteger Value { get; }

        /// <summary>
        /// 使用した状態リストを取得します。
        /// </summary>
        public IEnumerable<IState> States { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="states">状態リスト</param>
        /// <param name="value">数値</param>
        public StateNotFoundException(IEnumerable<IState> states, BigInteger value)
            : base($"当てはまる状態が見つかりませんでした。[{value}]")
        {
            States = states;
            Value = value;
        }
    }
}
