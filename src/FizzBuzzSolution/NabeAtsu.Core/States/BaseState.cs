using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States
{
    /// <summary>
    /// 状態基底クラス
    /// </summary>
    public abstract class BaseState : IState
    {
        /// <summary>
        /// 子状態リスト
        /// </summary>
        private IEnumerable<IState> _subStates = null;

        /// <summary>
        /// 有効かどうかを取得します。
        /// </summary>
        public bool Enabled => true;

        /// <summary>
        /// 子状態リストを取得します。
        /// </summary>
        public IEnumerable<IState> SubStates
        {
            get
            {
                if (_subStates == null)
                {
                    // 初回生成
                    _subStates = _CreateSubStates();
                }
                return _subStates;
            }
        }

        /// <summary>
        /// 指定された数値が状態の条件に当てはまるかどうかを取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態の条件に当てはまるかどうか</returns>
        public abstract bool IsApplied(BigInteger value);

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        public abstract Result Convert(BigInteger value);

        /// <summary>
        /// 子状態リストを生成します。
        /// </summary>
        /// <returns>子状態リスト</returns>
        protected abstract IEnumerable<IState> _CreateSubStates();
    }
}
