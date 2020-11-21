using NabeAtsu.Core.States;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

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

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="states">使用する状態リスト</param>
        /// <remarks>
        /// Builder経由で生成するため private とする。
        /// </remarks>
        private Player(IEnumerable<IState> states)
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
            var state = JudgeState(value);

            // 変換して返す
            return state.Convert(value);
        }

        /// <summary>
        /// どの状態に当てはまるかを判定します。
        /// </summary>
        /// <param name="value">数値</param>
        /// <returns></returns>
        public IState JudgeState(BigInteger value)
        {
            // 条件に当てはまる状態を取得する
            var states = _states
                .Where(state => state.Enabled && state.IsSatisfied(value))
                .OrderByDescending(state => state.Level);

            if (states.Count() == 0)
                // 当てはまる状態がなかった
                throw new StateNotFoundException(_states, value);

            // 最も優先度の高い状態を取得する
            return states.First();
        }

        public class Builder
        {
            private ICollection<IState> _States = new Collection<IState>();

            public Builder AddState(IState state)
            {
                _States.Add(state);
                return this;
            }

            public Player AutoBuild()
            {
                _States = new IState[]
                {
                    new States.Lv0.Default.DefaultState.Builder().Build(),
                    new States.Lv1.Dog.DogState.Builder().Build(),
                    new States.Lv1.Fool.FoolState.Builder().Build(),
                    new States.Lv2.FoolDog.FoolDogState.Builder().Build(),
                };
                return Build();
            }

            public Player Build() => new Player(_States.Distinct());
        }
    }
}
