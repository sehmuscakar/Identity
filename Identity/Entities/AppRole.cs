using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
	public class AppRole:IdentityRole<int>
	{
		public DateTime CreateTime { get; set; }
	}
}
