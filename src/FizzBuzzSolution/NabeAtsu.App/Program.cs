using Microsoft.Extensions.CommandLineUtils;
using NabeAtsu.Core;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Numerics;

namespace NabeAtsu.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false)
            {
                Name = "NabeAtsu.App",
                Description = "NabeAtsu Application by .NET Core.",
            };
            var helpOption = "-?|-h|--help";
            app.HelpOption(helpOption);

            var start = app.Option("start", "", CommandOptionType.SingleValue);

            app.Command("run", (command) =>
            {
                command.Description = "実行します。";
                command.HelpOption(helpOption);

                var start = command.Argument("start", "開始する数値");
                var count = command.Argument("count", "数える数");

                app.OnExecute(() =>
                {
                    if (!BigInteger.TryParse(start.Value, out var startValue))
                    {
                        return -1;
                    }
                    if (!BigInteger.TryParse(count.Value, out var countValue))
                    {
                        return -1;
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
                var start = app.Argument("start", "");

                Console.WriteLine(JsonConvert.SerializeObject(start));
                return 0;
            });

            app.Execute(args);
        }
    }
}
