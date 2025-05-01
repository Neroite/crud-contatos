using Lopobia.Models;

namespace Lopobia.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Criar(ContatoModel contato);
        List<ContatoModel> BuscarTodos();
        ContatoModel BuscarPorId(int id);
        ContatoModel Editar(ContatoModel contato);
        bool Apagar(int id);

    }
}
