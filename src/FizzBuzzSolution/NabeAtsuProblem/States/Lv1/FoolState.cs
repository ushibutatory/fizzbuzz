using NabeAtsuProblem.Utilities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NabeAtsuProblem.States.Lv1
{
	/// <summary>
	/// アホ状態クラス
	/// </summary>
	public class FoolState : BaseState
	{
		#region Private定数
		/// <summary>
		/// 単位の区切り種別
		/// </summary>
		/// <remarks>
		/// 4で割った余り
		/// </remarks>
		private enum DigitPartType
		{
			One = 1,
			Ten = 2,
			Hundred = 3,
			Thousand = 0
		}

		/// <summary>
		/// 単位の段階種別
		/// </summary>
		/// <remarks>
		/// 4で割った商
		/// </remarks>
		private enum DigitScaleType
		{
			一 = 0,
			万 = 1,
			億 = 2,
			兆 = 3,
			京 = 4,
			垓 = 5,
			抒 = 6,
			穣 = 7,
			溝 = 8,
			澗 = 9,
			正 = 10,
			載 = 11,
			極 = 12,
			恒河沙 = 13,
			阿僧祇 = 14,
			那由他 = 15,
			不可思議 = 16,
			無量大数 = 17
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 指定された数値が状態の条件に当てはまるかどうかを取得します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>状態の条件に当てはまるかどうか</returns>
		public override Boolean IsApplied(BigInteger value)
		{
			return (value % 3 == 0) || (value.ToString().Contains("3"));
		}

		/// <summary>
		/// 数値を変換します。
		/// </summary>
		/// <param name="value">数値</param>
		/// <returns>結果</returns>
		public override Result Convert(BigInteger value)
		{
			var result = new Result(this, value);

			var text = new StringBuilder();

			// 何桁目か（大きい桁から数える）
			var digit = value.ToString().Length;

			// 小さい桁から4桁ごとに分割する
			foreach (var block in StringUtility.SplitLength(value.ToString(), 4, StringUtility.SplitDirection.Back))
			{
				if (Int32.Parse(block) == 0)
				{
					// ブロックが0のみの場合は、何も出力しない
					digit -= block.Length;
				}
				else
				{
					// 1文字ずつ変換
					foreach (var c in block)
					{
						// 1桁分の数字を取得
						var n = Int32.Parse(c.ToString());

						// 数を変換
						text.Append(this._ToFoolNumber(n, digit));

						// 桁を変換
						text.Append(this._ToFoolDigit(n, digit));

						digit--;
					}
				}
			}

			result.Text = text.ToString();

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
			return new List<IState>() { new FoolState() };
		}
		#endregion

		#region Privateメソッド
		/// <summary>
		/// 数値をアホにします。
		/// </summary>
		/// <param name="number">元の数値</param>
		/// <param name="digit">桁数</param>
		/// <returns>アホな数値</returns>
		private String _ToFoolNumber(Int32 number, Int32 digit)
		{
			var result = "";
			if (digit == 1)
			{
				// 1の位
				switch (number)
				{
					case 0: result = ""; break;
					case 1: result = "いち"; break;
					case 2: result = "にぃ"; break;
					case 3: result = "さぁん"; break;
					case 4: result = "よぉん"; break;
					case 5: result = "ごぉ"; break;
					case 6: result = "ろぉく"; break;
					case 7: result = "ななぁ"; break;
					case 8: result = "はぁち"; break;
					case 9: result = "きゅう"; break;
				}
			}
			else
			{
				// 単位の区切りを取得
				var digitPart = this._GetDigitPart(digit);

				switch (number)
				{
					case 0: result = ""; break;
					case 1:
						switch (digitPart)
						{
							case DigitPartType.One:
								switch (this._GetDigitScale(digit))
								{
									case DigitScaleType.兆:
									case DigitScaleType.京:
									case DigitScaleType.澗:
									case DigitScaleType.正:
									case DigitScaleType.載:
										result = "いっ"; break;
									default:
										result = "いち"; break;
								}
								break;
							default:
								result = ""; break;
						}
						break;
					case 2: result = "に"; break;
					case 3: result = "さん"; break;
					case 4: result = "よん"; break;
					case 5: result = "ご"; break;
					case 6:
						switch (digitPart)
						{
							case DigitPartType.Hundred:
								result = "ろっ"; break;
							default:
								result = "ろく"; break;
						}
						break;
					case 7: result = "なな"; break;
					case 8:
						switch (digitPart)
						{
							case DigitPartType.Hundred:
							case DigitPartType.Thousand:
								result = "はっ"; break;
							default:
								result = "はち"; break;
						}
						break;
					case 9: result = "きゅう"; break;
				}
			}
			return result;
		}

		/// <summary>
		/// 桁をアホにします。
		/// </summary>
		/// <param name="number">元の数値</param>
		/// <param name="digit">桁数</param>
		/// <returns>アホな桁</returns>
		private String _ToFoolDigit(Int32 number, Int32 digit)
		{
			var result = "";
			switch (this._GetDigitPart(digit))
			{
				case DigitPartType.One:
					switch (this._GetDigitScale(digit))
					{
						case DigitScaleType.万: result = "まん"; break;
						case DigitScaleType.億: result = "おく"; break;
						case DigitScaleType.兆: result = "ちょー"; break;
						case DigitScaleType.京: result = "けぇー"; break;
						case DigitScaleType.垓: result = "がぃ"; break;
						case DigitScaleType.抒: result = "じょぉ"; break;
						case DigitScaleType.穣: result = "じょぅ"; break;
						case DigitScaleType.溝: result = "こお"; break;
						case DigitScaleType.澗: result = "かんん"; break;
						case DigitScaleType.正: result = "せーぃ"; break;
						case DigitScaleType.載: result = "さぁい"; break;
						case DigitScaleType.極: result = "ごく"; break;
						case DigitScaleType.恒河沙: result = "ごーがしゃー"; break;
						case DigitScaleType.阿僧祇: result = "あそーぎぃ"; break;
						case DigitScaleType.那由他: result = "なゆたぁ"; break;
						case DigitScaleType.不可思議: result = "ふかしぎぃー"; break;
						case DigitScaleType.無量大数: result = "むりょーたいすー"; break;
						default: break;
					}
					break;
				case DigitPartType.Ten:
					switch (number)
					{
						case 0: break;
						default:
							switch (this._GetDigitScale(digit))
							{
								case DigitScaleType.兆:
								case DigitScaleType.京:
								case DigitScaleType.溝:
								case DigitScaleType.澗:
								case DigitScaleType.正:
								case DigitScaleType.載:
									result = "じゅっ"; break;
								default:
									result = "じゅう"; break;
							}
							break;
					}
					break;
				case DigitPartType.Hundred:
					switch (number)
					{
						case 0: break;
						case 3:
							result = "びゃく"; break;
						case 6:
						case 8:
							result = "ぴゃく"; break;
						default:
							result = "ひゃく"; break;
					}
					break;
				case DigitPartType.Thousand:
					switch (number)
					{
						case 0: break;
						case 3:
							result = "ぜん"; break;
						default:
							result = "せん"; break;
					}
					break;
			}
			return result;
		}

		/// <summary>
		/// 単位の区切り種別を取得します。
		/// </summary>
		/// <param name="digit">単位</param>
		/// <returns>単位の区切り種別</returns>
		private DigitPartType? _GetDigitPart(Int32 digit)
		{
			return StringUtility.ToEnum<DigitPartType>((digit % 4).ToString());
		}

		/// <summary>
		/// 単位の段階種別を取得します。
		/// </summary>
		/// <param name="digit">単位</param>
		/// <returns>単位の段階種別</returns>
		private DigitScaleType? _GetDigitScale(Int32 digit)
		{
			return StringUtility.ToEnum<DigitScaleType>((digit / 4).ToString());
		}
		#endregion
	}
}
