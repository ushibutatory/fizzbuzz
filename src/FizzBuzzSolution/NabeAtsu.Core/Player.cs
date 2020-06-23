using NabeAtsu.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace NabeAtsu.Core
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 取りうる状態リスト
        /// </summary>
        private readonly IEnumerable<IState> _states;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Player()
        {
            // 状態リストを初期化
            _states = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(IState)))
                        .Select(type => (IState)Activator.CreateInstance(type));
        }

        /// <summary>
        /// 指定された数値を答えます。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>答え</returns>
        public Result Answer(BigInteger value)
        {
            // 状態を取得
            var state = _GetState(value);

            // 結果を取得
            return state.Convert(value);
        }

        /// <summary>
        /// 状態を取得します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns>状態</returns>
        private IState _GetState(BigInteger value)
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
