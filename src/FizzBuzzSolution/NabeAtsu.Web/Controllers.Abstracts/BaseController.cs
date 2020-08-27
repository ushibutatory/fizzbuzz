using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NabeAtsu.Web.Controllers.Abstracts
{
    public abstract class BaseController : Controller
    {
        protected readonly ILogger _logger;
        protected readonly AppSettings _appSettings;

        public BaseController(ILogger logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }
    }
}
