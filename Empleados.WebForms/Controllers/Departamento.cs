using CRUD.BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.WebForms.Controllers
{
    public class Departamento : Controller
    {
        DepartamentoBL departamentos = new DepartamentoBL();

        public IActionResult Index()
        {
            departamentos.List();
            return View();
        }

        public IActionResult Departamentos() 
        {
            return View(departamentos);  
        }
    }
}
