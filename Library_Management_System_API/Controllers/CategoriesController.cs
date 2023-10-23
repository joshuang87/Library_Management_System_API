using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
