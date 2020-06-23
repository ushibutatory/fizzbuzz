using System.Linq;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    public abstract class BaseDuplicateState : BaseState
    {
        /// <summary>
        /// 指定された数値が状態の条件に当てはまるかどうかを取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態の条件に当てはまるかどうか</returns>
        public override bool IsApplied(BigInteger value)
            // すべての構成要素が当てはまるかどうか
            => SubStates.ToList().TrueForAll((state) => state.IsApplied(value));
    }
}
