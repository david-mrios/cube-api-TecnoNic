using Microsoft.AspNetCore.Mvc;

namespace cube_api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Bienvenido al cubo api");
        }
    }

}
