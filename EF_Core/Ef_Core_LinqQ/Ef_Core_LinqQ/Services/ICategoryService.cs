using Ef_Core_LinqQ.Data;
using Ef_Core_LinqQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_LinqQ.Services
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync();
    }
    public class CategoryService : ICategoryService
    {
        AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
