using NabeAtsuProblem.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States.Lv2
{
	/// <summary>
	/// 気持ちいいアホ状態
	/// </summary>
	public class GoodFeelingFoolState : BaseDuplicateState
	{
		#region Private変数
		/// <summary>
		/// アホ状態オブジェクト
		/// </summary>
		/// <remarks>
		/// テキスト生成用
		/// </remarks>
		private FoolState _fool = new FoolState();
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		public override Result Convert(BigInteger value)
		{
			var result = new Result(this, value);

			result.Text = this._fool.Convert(value).Text + "(*´ω｀*)";

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
			return new List<IState>() {
				new FoolState()
				, new GoodFeelingState()
			};
		}
		#endregion
	}
}
