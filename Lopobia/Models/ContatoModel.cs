using System.ComponentModel.DataAnnotations;

namespace Lopobia.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Email")]
        [EmailAddress(ErrorMessage ="Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular")]
        [Phone(ErrorMessage = "Digite um Celular Válido")]
        public string Celular { get; set; }
    }
}
