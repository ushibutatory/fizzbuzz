using NabeAtsu.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace NabeAtsu.Core
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 最大値
        /// </summary>
        /// <remarks>
        /// 無量大数は10の68乗なので
        /// 10の73乗-1＝9999無量大数9999...9999
        /// </remarks>
        private static readonly BigInteger MaxValue = BigInteger.Pow(10, (68 + 4) + 1) - 1;

        /// <summary>
        /// 使用する状態リスト
        /// </summary>
        private readonly IEnumerable<IState> _states;

        public Player()
        {
            // 状態リストを初期化
            _states = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(IState)))
                        .Select(type => (IState)Activator.CreateInstance(type));
        }

        public Player(IEnumerable<IState> states)
        {
            _states = states;
        }

        /// <summary>
        /// 数値をカウントしていきます。
        /// </summary>
        /// <param name="start">開始数</param>
        /// <param name="count">数える数</param>
        /// <returns>結果リスト</returns>
        public IEnumerable<Result> Answer(BigInteger start, BigInteger count)
        {
            var end = start + count;

            for (var i = start; i < end; i++)
            {
                if (i > MaxValue)
                {
                    yield return new Result.Builder
                    {
                        UsingState = null,
                        OriginalValue = i,
                        ConvertedText = "これ以上は数えられません",
                    }.Build();
                }
                else
                {
                    yield return Answer(i);
                }
            }
        }

        /// <summary>
        /// 数値を変換します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>結果</returns>
        public Result Answer(BigInteger value)
        {
            // 状態を取得
            var state = _GetState(value);

            // 変換して返す
            return state.Convert(value);
        }

        private IState _GetState(BigInteger value)
        /// <summary>
        /// どの状態に当てはまるかを判定します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns></returns>
        {
            // 条件に当てはまる状態を取得する
            var states = _states
                .Where(state => state.IsApplied(value) && state.Enabled)
                .OrderByDescending(state => state.SubStates.Count());

            if (states.Count() == 0)
                // 当てはまる状態がなかった
                throw new StateNotFoundException(_states, value);

            // 最も優先度の高い状態（＝子状態が多いほど優先度が高い）を取得する
            return states.First();
        }
    }
}
