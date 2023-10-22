using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private ApplicationDbContext _dbContext;
		public BooksController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
