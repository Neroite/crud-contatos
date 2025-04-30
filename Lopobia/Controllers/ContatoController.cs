using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ConfirmarApagar()
        {
            return View();
        }
    }
}
