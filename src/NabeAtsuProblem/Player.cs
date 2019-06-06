using NabeAtsuProblem.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace NabeAtsuProblem
{
	/// <summary>
	/// プレイヤークラス
	/// </summary>
	public class Player
	{
		#region Private変数
		/// <summary>
		/// 取りうる状態リスト
		/// </summary>
		private readonly List<IState> _states;
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		public Player()
		{
			// 状態リストを初期化
			this._states = new List<IState>();
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(IState)))
				{
					// 状態インタフェースを実装している具象クラスをインスタンス化して格納
					this._states.Add((IState)Activator.CreateInstance(type));
				}
			}
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 指定された数値を答えます。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>答え</returns>
		public Result Answer(BigInteger value)
		{
			// 状態を取得
			var state = this._GetState(value);

			// 結果を取得
			return state.Convert(value);
		}
		#endregion

		#region Privateメソッド
		/// <summary>
		/// 状態を取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態</returns>
		private IState _GetState(BigInteger value)
		{
			// 条件に当てはまる状態を取得する
			var states = from item in this._states
						 where item.IsApplied(value) && item.Enabled
						 orderby item.SubStateList.Count descending
						 select item;

			// 最も優先度の高い状態（＝子状態が多いほど優先度が高い）を取得する
			IState state = null;
			if (states.Count() > 0)
			{
				state = states.First();
			}

			if (state == null)
			{
				// 当てはまる状態がなかった
				throw new StateNotFoundException(this._states, value);
			}

			return state;
		}
		#endregion
	}
}
