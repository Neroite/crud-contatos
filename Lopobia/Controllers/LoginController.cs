using Lopobia.Models;
using Lopobia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "A senha do usuário é inválida, tente novamente";
                        return View("Index");
                    }

                    TempData["MensagemErro"] = "Login e/ou senha inválido(s). Por favor tente novamente.";
                }

                return View("Index");

            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = "Não conseguimos realizar o Login, tente novamnete";
                return RedirectToAction("Index");
            }
        }
    }
}
