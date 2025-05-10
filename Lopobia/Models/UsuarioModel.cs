using Lopobia.Enum;
using Lopobia.Helper;
using System.ComponentModel.DataAnnotations;

namespace Lopobia.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite um nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite um Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite um email")]
        [EmailAddress(ErrorMessage ="Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

    }
}
