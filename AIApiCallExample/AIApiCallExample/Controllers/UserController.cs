using AIApiCallExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIApiCallExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static MyService _myService;
        public UserController(MyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var apiKey = _myService.GetApiKey();
            ViewBag.apiKey = apiKey;
            return View();
        }
    }
}
