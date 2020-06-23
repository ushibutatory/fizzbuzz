using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv1
{
    /// <summary>
    /// 犬状態
    /// </summary>
    public class DogState : BaseState
    {
        /// <summary>
        /// 指定された数値が状態の条件に当てはまるかどうかを取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態の条件に当てはまるかどうか</returns>
        public override bool IsApplied(BigInteger value)
            => value % 5 == 0;

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        public override Result Convert(BigInteger value)
            => new Result(this, value)
            {
                Text = "わん！U^ｪ^U"
            };

        /// <summary>
        /// サブ状態リストを生成します。
        /// </summary>
        /// <returns>サブ状態リスト</returns>
        protected override IEnumerable<IState> _CreateSubStates()
            => new[] { new DogState() };
    }
}
