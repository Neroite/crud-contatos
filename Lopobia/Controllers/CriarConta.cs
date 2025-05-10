using Lopobia.Filters;
using Lopobia.Models;
using Lopobia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    [PaginaParaCriarConta]
    public class CriarConta : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarConta(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Criar(usuario);
                    return RedirectToAction("Index","Login");
                }

                return View("Index", usuario);
                // ou return View("Criar",usuario); caso a view não tenha o mesmo nome que o método
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na criação do usuario. detalhes do erro: {erro}";
                return View();
            }

        }
    }
}
