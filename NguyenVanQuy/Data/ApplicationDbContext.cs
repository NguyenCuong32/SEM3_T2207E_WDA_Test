using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NguyenVanQuy.Models;

namespace NguyenVanQuy.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<NguyenVanQuy.Models.Department>? Department { get; set; }
		public DbSet<NguyenVanQuy.Models.Employee>? Employee { get; set; }
	}
}