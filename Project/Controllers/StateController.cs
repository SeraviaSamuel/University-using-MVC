using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class StateController : Controller
    {
        int count = 0;
        public StateController()
        {
            count++;
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 20);
            return Content("Session Data Save");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int age = HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name={name} \t Age={age}");

        }
    }
}
