using System.ComponentModel.DataAnnotations;

namespace Wallet.UI.Models
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "Az e-mail címet kötelező megadni.")]
        [EmailAddress(ErrorMessage = "Érvénytelen e-mail cím.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Az jelszót kötelező megadni.")]
        public string Password { get; set; }
    }
}