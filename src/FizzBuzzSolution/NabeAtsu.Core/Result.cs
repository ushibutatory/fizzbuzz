using NabeAtsu.Core.States;
using System;
using System.Numerics;

namespace NabeAtsu.Core
{
    /// <summary>
    /// 結果クラス
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 元の数値を取得または設定します。
        /// </summary>
        public BigInteger Value { get; set; }

        /// <summary>
        /// 変換後の文字列を取得または設定します。
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 適用した状態を取得または設定します。
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// 適用した状態の型を取得します。
        /// </summary>
        public Type StateType => State.GetType();

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="state">状態クラス</param>
        /// <param name="value">数値</param>
        public Result(IState state, BigInteger value)
        {
            Value = value;
            State = state;
            Text = string.Empty;
        }

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"{Value}-({StateType.Name})->{Text}";
    }
}
