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
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Contato realizado com sucesso!";
                    _contatoRepositorio.Criar(contato);
                    return RedirectToAction("Index");
                }

                return View(contato);
                // ou return View("Criar",contato); caso a view não tenha o mesmo nome que o método
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na criação do contato. detalhes do erro: {erro}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    _contatoRepositorio.Editar(contato);
                    return RedirectToAction("Index");
                }

                return View(contato);
            }

            catch (Exception)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na edição do contato";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Apagar(int id)
        {   

            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o contato";
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na deleção do contato";
                return RedirectToAction("Index");
            }
        }
    }
}
