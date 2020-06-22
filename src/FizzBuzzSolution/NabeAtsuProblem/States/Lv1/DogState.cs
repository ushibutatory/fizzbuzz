using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States.Lv1
{
	/// <summary>
	/// 犬状態
	/// </summary>
	public class DogState : BaseState
	{
		#region Publicメソッド
		/// <summary>
		/// 指定された数値が状態の条件に当てはまるかどうかを取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態の条件に当てはまるかどうか</returns>
		public override Boolean IsApplied(BigInteger value)
		{
			return (value % 5 == 0);
		}

		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		public override Result Convert(BigInteger value)
		{
			var result = new Result(this, value);

			result.Text = "わん！U^ｪ^U";

			return result;
		}
		#endregion

		#region Protectedメソッド
		/// <summary>
		/// サブ状態リストを生成します。
		/// </summary>
		/// <returns>サブ状態リスト</returns>
		protected override List<IState> _CreateSubStateList()
		{
			return new List<IState>() { new DogState() };
		}
		#endregion
	}
}
