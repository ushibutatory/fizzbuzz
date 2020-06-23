using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv0
{
    /// <summary>
    /// 通常
    /// </summary>
    public class DefaultState : BaseState
    {
        /// <summary>
        /// 指定された数値が状態の条件に当てはまるかどうかを取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態の条件に当てはまるかどうか</returns>
        public override bool IsApplied(BigInteger value)
            // 常に
            => true;

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        public override Result Convert(BigInteger value)
            => new Result(this, value)
            {
                Text = value.ToString()
            };

        /// <summary>
        /// サブ状態リストを生成します。
        /// </summary>
        /// <returns>サブ状態リスト</returns>
        protected override IEnumerable<IState> _CreateSubStates()
            // 空
            => Enumerable.Empty<IState>();
    }
}
