using System;
using System.Numerics;

namespace NabeAtsuProblem.States
{
	/// <summary>
	/// 状態重複基底クラス
	/// </summary>
	public abstract class BaseDuplicateState : BaseState
	{
		#region Publicメソッド
		/// <summary>
		/// 指定された数値が状態の条件に当てはまるかどうかを取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態の条件に当てはまるかどうか</returns>
		public override Boolean IsApplied(BigInteger value)
		{
			// すべての構成要素が当てはまるかどうか
			return this.SubStateList.TrueForAll((state) => state.IsApplied(value));
		}
		#endregion
	}
}
