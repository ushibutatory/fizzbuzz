using NabeAtsu.Core.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsu.Core.States.Lv2
{
    /// <summary>
    /// 気持ちいいアホ状態
    /// </summary>
    public class GoodFeelingFoolState : BaseDuplicateState
    {
        /// <summary>
        /// アホ状態オブジェクト
        /// </summary>
        /// <remarks>
        /// テキスト生成用
        /// </remarks>
        private FoolState _fool = new FoolState();

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        public override Result Convert(BigInteger value)
            => new Result(this, value)
            {
                Text = _fool.Convert(value).Text + "(*´ω｀*)"
            };

        /// <summary>
        /// サブ状態リストを生成します。
        /// </summary>
        /// <returns>サブ状態リスト</returns>
        protected override IEnumerable<IState> _CreateSubStates()
            => new IState[] {
                new FoolState(),
                new GoodFeelingState(),
            };
    }
}
