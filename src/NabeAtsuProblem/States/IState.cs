using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States
{
	/// <summary>
	/// 状態インタフェース
	/// </summary>
	public interface IState
	{
		#region プロパティ
		/// <summary>
		/// 有効かどうかを取得します。
		/// </summary>
		Boolean Enabled { get; }

		/// <summary>
		/// 子状態リストを取得します。
		/// </summary>
		List<IState> SubStateList { get; }
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 指定された数値が状態の条件に当てはまるかどうかを取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態の条件に当てはまるかどうか</returns>
		Boolean IsApplied(BigInteger value);

		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		Result Convert(BigInteger value);
		#endregion
	}
}
