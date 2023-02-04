using Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Context
{
	public class IdentityContext:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu syntax yapısı sabit gibi düşün core de veritabanı bağlantısı böyle oluyor sql de vartabı olarak yansıtılacak 
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-O9RRR03;database=IdentityDb; TrustServerCertificate=True; integrated security=true");
		}
	
	}
}
