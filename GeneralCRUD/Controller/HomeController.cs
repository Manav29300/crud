using Microsoft.AspNetCore.Mvc;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("/")]  // This maps to the root path
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to the CRUD API!");
        }
    }
}
