using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fuente0.api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Fuente0Controller:ControllerBase
    {
        public Fuente0Controller()
        {
        }
        [HttpGet("/")]
        public IActionResult Public()
        {
            return Ok(new
            {
                Message = "This is the fuente0.com api. Be good."
            });
        }

        [HttpGet("private")]
        [Authorize]
        public IActionResult PrivateTest()
        {
            
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }

        [HttpGet("private-scoped")]
        [Authorize("read:messages")]
        public IActionResult ScopedTest()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }

        // This is a helper action. It allows you to easily view all the claims of the token.
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}
