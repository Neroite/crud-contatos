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
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Criar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Atualizar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {   
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
