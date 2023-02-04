

using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
	public class UserCreateModel
	{
		[Required(ErrorMessage ="Kullanıcı Adı gereklidir.")]
		public string UserName { get; set; }
		[EmailAddress(ErrorMessage ="Lütfen bir email formatı giriniz.")]
		[Required(ErrorMessage ="Email adresi gereklidir")]
		public string Email { get; set; }
        [Required(ErrorMessage = "Parola Alanı gereklidir")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parola tekrar gir")]
        [Compare("Password",ErrorMessage ="Parololar eşleşmiyor.")]
		public string ConfirePassword { get; set; }
        [Required(ErrorMessage = "Gender gereklidir")]
        public string Gender { get; set; }
	}
}
