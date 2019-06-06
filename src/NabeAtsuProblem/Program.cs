using NabeAtsuProblem.Utilities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NabeAtsuProblem
{
	/// <summary>
	/// ナベアツ問題
	/// </summary>
	public class Program
	{
		/// <summary>
		/// 最大値
		/// </summary>
		/// <remarks>
		/// 無量大数は10の68乗なので
		/// 10の73乗-1＝9999無量大数9999...9999
		/// </remarks>
		private static readonly BigInteger MaxValue = BigInteger.Pow(10, (68 + 4) + 1) - 1;

		/// <summary>
		/// エントリポイント
		/// </summary>
		/// <param name="args"></param>
		public static void Main(String[] args)
		{
			try
			{
				// 引数を変換
				var converter = new ArgsConverter(args);
				if (converter.ErrorList.Count > 0)
				{
					// 引数エラー
					var text = new StringBuilder();
					text.AppendLine();
					text.AppendLine("使用方法: nabeatsu 開始 カウント数");
					text.AppendLine("例）nabeatsu 1 100");
					text.AppendLine("引数はどちらも1以上の整数で指定してください。");
					Console.WriteLine(text.ToString());
				}
				else
				{
					// 引数を取得
					var start = converter.Start.Value;
					var count = converter.Count.Value;

					var end = start + count;

					// プレイヤーを生成
					var player = new Player();

					for (var i = start; i < end; i++)
					{
						if (i > MaxValue)
						{
							Console.WriteLine("これ以上は数えられません");
							break;
						}
						else
						{
							// 回答を取得
							var result = player.Answer(i);

							// 出力
							Console.WriteLine(result.Text);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 引数変換クラス
		/// </summary>
		private class ArgsConverter
		{
			#region Public定数
			/// <summary>
			/// エラー種別
			/// </summary>
			public enum ErrorType
			{
				/// <summary>
				/// 引数の数が少ない
				/// </summary>
				ArgsCount_Short,
				/// <summary>
				/// 開始指定が不正
				/// </summary>
				Start_Invalid,
				/// <summary>
				/// カウント指定が不正
				/// </summary>
				Count_Invalid
			}
			#endregion

			#region コンストラクタ
			/// <summary>
			/// 新しいインスタンスを生成します。
			/// </summary>
			/// <param name="args">引数</param>
			public ArgsConverter(String[] args)
			{
				// 元の引数を保持
				this.Args = args;

				var errorList = new List<ErrorType>();
				if (args.Length < 2)
				{
					errorList.Add(ErrorType.ArgsCount_Short);
				}
				else
				{
					// 引数を数値に変換
					this.Start = StringUtility.ToBigInteger(args[0]);
					this.Count = StringUtility.ToBigInteger(args[1]);

					if (this.Start == null || this.Start.Value <= 0)
					{
						errorList.Add(ErrorType.Start_Invalid);
					}
					if (this.Count == null || this.Count.Value <= 0)
					{
						errorList.Add(ErrorType.Count_Invalid);
					}
				}
				this.ErrorList = errorList;
			}
			#endregion

			#region プロパティ
			/// <summary>
			/// 元の引数を取得します。
			/// </summary>
			public String[] Args { get; private set; }

			/// <summary>
			/// 開始指定を取得します。
			/// </summary>
			public BigInteger? Start { get; private set; }

			/// <summary>
			/// カウント指定を取得します。
			/// </summary>
			public BigInteger? Count { get; private set; }

			/// <summary>
			/// エラーリストを取得します。
			/// </summary>
			public List<ErrorType> ErrorList { get; private set; }
			#endregion
		}
	}
}
