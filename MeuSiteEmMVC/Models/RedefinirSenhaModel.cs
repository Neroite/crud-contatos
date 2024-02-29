using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        public string Email { get; set; }
    }
}
