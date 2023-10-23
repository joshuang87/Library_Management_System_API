using Library_Management_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System_API
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
    }
}
