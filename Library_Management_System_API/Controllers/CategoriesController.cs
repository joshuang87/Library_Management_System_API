using Library_Management_System_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
		private readonly ApplicationDbContext _dbContext;
        public CategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Category>> GetAll()
        {
            try
            {
                return Ok(await _dbContext.Categories.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(Category request)
        {
            try
            {
                var category = new Category
                {
                    Category_Name = request.Category_Name,
                };

                await _dbContext.AddAsync(category);
                await _dbContext.SaveChangesAsync();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
