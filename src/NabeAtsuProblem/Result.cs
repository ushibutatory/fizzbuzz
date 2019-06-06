using NabeAtsuProblem.States;
using System;
using System.Numerics;

namespace NabeAtsuProblem
{
	/// <summary>
	/// 結果クラス
	/// </summary>
	public class Result
	{
		#region プロパティ
		/// <summary>
		/// 元の数値を取得または設定します。
		/// </summary>
		public BigInteger Value { get; set; }

		/// <summary>
		/// 変換後の文字列を取得または設定します。
		/// </summary>
		public String Text { get; set; }

		/// <summary>
		/// 適用した状態を取得または設定します。
		/// </summary>
		public IState State { get; set; }

		/// <summary>
		/// 適用した状態の方を取得します。
		/// </summary>
		public Type StateType { get { return this.State.GetType(); } }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="state">状態クラス</param>
		/// <param name="value">数値</param>
		public Result(IState state, BigInteger value)
		{
			this.Value = value;
			this.State = state;
			this.Text = String.Empty;
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 現在のオブジェクトを表す文字列を返します。
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			return String.Format("{0}-({1})->{2}", this.Value, this.StateType.Name, this.Text);
		}
		#endregion
	}
}
