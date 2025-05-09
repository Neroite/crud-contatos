using Lopobia.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
