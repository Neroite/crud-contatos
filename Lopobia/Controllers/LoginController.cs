using Lopobia.Helper;
using Lopobia.Models;
using Lopobia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lopobia.Controllers
{
    public class LoginController : Controller
    {   

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar para home 
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
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
                            _sessao.CriarSessaoUsuario(usuario);
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
