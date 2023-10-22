using Microsoft.EntityFrameworkCore;

namespace Library_Management_System_API
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
