using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmailElogin(string email, string login);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
