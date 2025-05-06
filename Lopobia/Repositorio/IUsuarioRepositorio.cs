using Lopobia.Models;

namespace Lopobia.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel Criar(UsuarioModel usuario);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Editar(UsuarioModel usuario);
        bool Apagar(int id);

    }
}
