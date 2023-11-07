using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReactForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("WELCOME to HomePage");
        }
    }
}
