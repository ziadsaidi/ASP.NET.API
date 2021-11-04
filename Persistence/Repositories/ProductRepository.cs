using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductRepository:BaseRepository,IProductRepository
    {
       
         public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<Product>> GetALlAsync()
        {
         return await _context.Products.Include(p => p.Category)
                                          .ToListAsync();
        }

      
    }
}