using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.RegexRunner;

namespace WebApiHW_8._08._22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegexController : ControllerBase
    {
        private IRegexRunner _runner { get; set; }
        public RegexController(IRegexRunner runner)
        {
            _runner = runner;
        }
        [HttpGet("string/{str}")]
        public IActionResult BasicRun([FromRoute] string str)
        {
            return Ok(_runner.BasicClearString(str));
        }
    }
}
