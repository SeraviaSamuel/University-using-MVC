using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
