using Lopobia.Models;
using Lopobia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contatos = _contatoRepositorio.BuscarPorId(id);
            return View(contatos);
        }

        public IActionResult ConfirmarApagar(int id)
        {
            ContatoModel contatos = _contatoRepositorio.BuscarPorId(id);
            return View(contatos);
        }

        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {

            if (ModelState.IsValid)
            {
                _contatoRepositorio.Criar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            if (ModelState.IsValid)
            {
                _contatoRepositorio.Editar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        public IActionResult Apagar(int id)
        {   
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
