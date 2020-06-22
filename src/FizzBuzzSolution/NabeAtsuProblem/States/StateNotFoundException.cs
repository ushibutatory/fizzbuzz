using System;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States
{
	/// <summary>
	/// 当てはまる状態が見つからない時の例外
	/// </summary>
	public class StateNotFoundException : Exception
	{
		#region プロパティ
		/// <summary>
		/// 対象の数値を取得します。
		/// </summary>
		public BigInteger Value { get; private set; }

		/// <summary>
		/// 使用した状態リストを取得します。
		/// </summary>
		public List<IState> StateList { get; private set; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="stateList">状態リスト</param>
		/// <param name="value">数値</param>
		public StateNotFoundException(List<IState> stateList, BigInteger value)
			: base(String.Format("当てはまる状態が見つかりませんでした。[{0}]", value))
		{
			this.StateList = stateList;
			this.Value = value;
		}
		#endregion
	}
}
