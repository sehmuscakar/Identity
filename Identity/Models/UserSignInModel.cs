

using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage ="Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Parola gerklidir.")]
        public string Password { get; set; }
    }
}
