using Microsoft.AspNetCore.Mvc;

namespace Empleados.WebForms.Controllers
{
    public class Empleado : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewEmpleado()
        {
            return View(new Empleado());
        }
    }
}