using Lopobia.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lopobia.Models
{
    public class UsuarioSemSenhaModel
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

    }
}
