using Microsoft.Extensions.CommandLineUtils;
using NabeAtsu.Core;
using System;
using System.Linq;
using System.Numerics;

namespace NabeAtsu.App
{
    public class Program
    {
        private static int Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false)
            {
                Name = "NabeAtsu.App",
                Description = "NabeAtsu Application by .NET Core.",
            };

            // help
            const string helpOption = "-?|-h|--help";
            app.HelpOption(template: helpOption);

            app.Command("run", (command) =>
            {
                command.Description = "実行します。";
                command.HelpOption(helpOption);

                var start = command.Argument("start", "開始する数値");
                var count = command.Argument("count", "数える数");

                command.OnExecute(() =>
                {
                    if (!BigInteger.TryParse(start.Value, out var startValue))
                    {
                        return command.Execute("-h");
                    }
                    if (!BigInteger.TryParse(count.Value, out var countValue))
                    {
                        return command.Execute("-h");
                    }

                    var endValue = startValue + countValue;

                    // プレイヤーを生成
                    var player = new Player();

                    var results = player.Answer(startValue, countValue);

                    Console.WriteLine(string.Join(Environment.NewLine, results.Select(result => result.ConvertedText)));

                    return 0;
                });
            });

            app.OnExecute(() =>
            {
                // 引数なしで実行された場合はヘルプ表示
                return app.Execute("-h");
            });

            return app.Execute(args);
        }
    }
}
