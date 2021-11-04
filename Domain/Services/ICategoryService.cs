using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<CategoryResponse> SaveAsync(Category category);

        Task<CategoryResponse> UpdateAsync(int id, Category category);

        Task<CategoryResponse> DeleteAsync(int id);
    }
}