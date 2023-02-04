using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
	public class AppUser:IdentityUser<int>
	{
		public string ImagePath { get; set; }
		//3NF ye aykırı genderin ayrı bi tabloda olması lazım bi şeyi güncelerken ayrı bi tabloda olması lazım
		public string Gender { get; set; }
	}
}
