using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Helper;
using System.Linq;

namespace eCommerce.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        [HttpPost]
        public IActionResult Index([FromBody]Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new {
                        Field = x.Key,
                        Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                    });

                        return BadRequest(new
                        {
                            Message = "Validation failed",
                            Errors = errors
                        });
            }

            return Ok("Success");
        }
    }
}
