using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        AppDbContextFactory _appDbContext;

        public CategoriesController(AppDbContextFactory appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<List<Category>> GetAll()
        {
            var categories =await _appDbContext.CreateContext().Categories.ToListAsync();
            return categories;
        }
    }
}
