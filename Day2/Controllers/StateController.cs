using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetSession()
        {

            HttpContext.Session.SetInt32("Age", 19);
            HttpContext.Session.SetString("Name", "Fatma");

            return Content("Saved....................................................");
            
        }

        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int age         = HttpContext.Session.GetInt32("Age").Value;

            return Content($"name= {name} \n age={age}");
        }
    }
}
