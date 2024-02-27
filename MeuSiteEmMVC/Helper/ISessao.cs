using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoUssuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
