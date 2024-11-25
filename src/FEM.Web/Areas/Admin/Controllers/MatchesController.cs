using Microsoft.AspNetCore.Mvc;

namespace FEM.Web.Areas.Admin.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
