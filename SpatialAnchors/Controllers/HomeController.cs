using Microsoft.AspNetCore.Mvc;

namespace SpatialAnchors.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        public HomeController(AnchorsController anchors)
        {
            Anchors = anchors;
        }

        public AnchorsController Anchors { get; }

        [HttpGet]
        public IActionResult Index()
        {
            var model = Anchors.Get("");
            return View("Home", model);
        }
    }
}
