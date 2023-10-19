using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Gozolop.Core.Aws.Lambda.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NabeAtsu.Core;
using System.Net;
using System.Numerics;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace NabeAtsu.Lambda;

public class Function
{
    public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        switch (request.HttpMethod)
        {
            case "OPTIONS":
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Headers = new Dictionary<string, string> {
                        { "Access-Control-Allow-Headers", "Content-Type" },
                        { "Access-Control-Allow-Origin", "*" },
                        { "Access-Control-Allow-Methods", "OPTIONS, POST" }
                    },
                };

            case "POST":
                var provider = new Func<IServiceProvider>(() =>
                {
                    var services = new ServiceCollection()
                        .AddLogging(logging =>
                        {
                            logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
                            logging.AddProvider(new LambdaLoggerProvider(context));
                        });
                    return services.BuildServiceProvider();
                })();

                var logger = provider.GetService<ILogger<Function>>();
                logger.LogInformation("ILambdaContext: {context}", JsonSerializer.Serialize(context));

                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var args = JsonSerializer.Deserialize<Arguments>(request.Body, serializerOptions)
                    ?? throw new InvalidRequestException(request);
                if (!BigInteger.TryParse(args.Start, out var start)) throw new InvalidRequestException(request);
                if (!BigInteger.TryParse(args.Count, out var count)) throw new InvalidRequestException(request);

                var player = new Player.Builder().AutoBuild();
                var answer = player.Answer(start, count).ToArray();
                logger.LogDebug("Answer is {answer}", answer);

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsBase64Encoded = false,
                    Headers = new Dictionary<string, string> {
                        { "Content-Type", "application/json" },
                    },
                    Body = JsonSerializer.Serialize(answer),
                };

            default:
                throw new Exception($"Not implemented Http method. {request.HttpMethod}");
        }
    }

    public class Arguments
    {
        public string? Start { get; set; } = string.Empty;

        public string? Count { get; set; } = string.Empty;
    }

    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(APIGatewayProxyRequest request)
            : base($"Argument is invalid. [{request.Body}]")
        { }
    }
}
