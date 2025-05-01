using Lopobia.Models;
using Lopobia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            try
            {
                List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
                return View(usuario);
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ConfirmarApagar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    _usuarioRepositorio.Criar(usuario);
                    return RedirectToAction("Index");
                }

                return View(usuario);
                // ou return View("Criar",usuario); caso a view não tenha o mesmo nome que o método
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na criação do usuario. detalhes do erro: {erro}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "usuario atualizado com sucesso!";
                    _usuarioRepositorio.Editar(usuario);
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }

            catch (Exception)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na edição do usuario";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Apagar(int id)
        {   

            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario deletado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o usuario";
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro na deleção do usuario";
                return RedirectToAction("Index");
            }
        }
    }
}
