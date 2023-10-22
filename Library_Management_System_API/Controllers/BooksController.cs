using Library_Management_System_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		public BooksController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllBooks()
		{
			try
			{
				var books = await _dbContext.Books.ToListAsync();

				return Ok(books);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateBook(Book request)
		{
			try
			{
				var book = new Book
				{
					Book_Id = request.Book_Id,
					Book_Title = request.Book_Title,
					Author = request.Author,
					Category_Id = request.Category_Id,
					Created_Time = DateTime.Now,
					Updated_Time = DateTime.Now,
				};

				await _dbContext.AddAsync(book);
				await _dbContext.SaveChangesAsync();

				return Ok(book);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
