using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bookstore.Web.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public HomeController(IOptionsSnapshot<AppSettings> settings)
        {
            _settings = settings;
        }

        [HttpGet("configuration")]
        public ActionResult Configuration()
        {
            return Ok(_settings.Value);
        }
    }
}
