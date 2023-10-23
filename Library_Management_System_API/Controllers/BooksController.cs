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

		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetBook(string id)
		{
			try
			{
				var book = await _dbContext.Books.FindAsync(id);

				return book == null ? NotFound() : Ok(book);
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

		[HttpPut("Update/{id}")]
		public async Task<ActionResult<Book>> Update(string id, Book request)
		{
			var bookToUpdate = await _dbContext.Books.FirstOrDefaultAsync(book => book.Book_Id == id);

			if (bookToUpdate == null) return NotFound();
			
			bookToUpdate.Book_Title = request.Book_Title;
			bookToUpdate.Author = request.Author;
			bookToUpdate.Category_Id = request.Category_Id;
			bookToUpdate.Updated_Time = DateTime.Now;

			try
			{
				await _dbContext.SaveChangesAsync();

				return Ok(bookToUpdate);
			}
			catch (DbUpdateConcurrencyException)
			{
				return BadRequest();
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var book = await _dbContext.Books.FindAsync(id);

			if (book == null) return NotFound();

			try
			{
				_dbContext.Books.Remove(book);
				await _dbContext.SaveChangesAsync();

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
