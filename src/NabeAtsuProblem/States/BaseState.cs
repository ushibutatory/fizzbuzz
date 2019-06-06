using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States
{
	/// <summary>
	/// 状態基底クラス
	/// </summary>
	public abstract class BaseState : IState
	{
		#region Private変数
		/// <summary>
		/// 子状態リスト
		/// </summary>
		private List<IState> _subStateList = null;
		#endregion

		#region プロパティ
		/// <summary>
		/// 有効かどうかを取得します。
		/// </summary>
		public Boolean Enabled
		{
			get { return true; }
		}
		
		/// <summary>
		/// 子状態リストを取得します。
		/// </summary>
		public List<IState> SubStateList
		{
			get
			{
				if (this._subStateList == null)
				{
					// 初回生成
					this._subStateList = this._CreateSubStateList();
				}
				return this._subStateList;
			}
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 指定された数値が状態の条件に当てはまるかどうかを取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態の条件に当てはまるかどうか</returns>
		public abstract Boolean IsApplied(BigInteger value);

		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		public abstract Result Convert(BigInteger value);
		#endregion

		#region Protectedメソッド
		/// <summary>
		/// 子状態リストを生成します。
		/// </summary>
		/// <returns>子状態リスト</returns>
		protected abstract List<IState> _CreateSubStateList();
		#endregion
	}
}
