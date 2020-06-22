using NabeAtsuProblem.States.Lv1;
using System.Collections.Generic;
using System.Numerics;

namespace NabeAtsuProblem.States.Lv2
{
	/// <summary>
	/// 気持ちいい犬状態
	/// </summary>
	public class GoodFeelingDogState : BaseDuplicateState
	{
		#region Publicメソッド
		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		public override Result Convert(BigInteger value)
		{
			var result = new Result(this, value);

			result.Text = "わふんU*´ω｀*U";

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
				new DogState()
				, new GoodFeelingState()
			};
		}
		#endregion
	}
}
