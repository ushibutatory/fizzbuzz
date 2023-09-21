using Microsoft.AspNetCore.Mvc;
using NabeAtsu.Api.Models;
using NabeAtsu.Core;
using System.Numerics;

namespace NabeAtsu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayController : Controller
    {
        private readonly ILogger<PlayController> _logger;

        public PlayController(ILogger<PlayController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Play")]
        public async Task<IActionResult> Play(PlayModel play)
        {
            if (!BigInteger.TryParse(play.Start, out var start)
                || !BigInteger.TryParse(play.Count, out var count))
            {
                return BadRequest(new PlayModel.Error("Parameters must be BigInteger.", play));
            }

            var result = await Task.Run<IEnumerable<Result>>(() =>
            {
                var player = new Player.Builder().AutoBuild();
                return player.Answer(start, count);
            });

            _logger.LogDebug($"Play: {play}, Result: {result}");

            return Ok(result);
        }
    }
}
