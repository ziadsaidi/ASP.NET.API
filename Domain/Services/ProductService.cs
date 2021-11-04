using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Domain.Services
{
    public class ProductService : IProductService

    
    {
         private readonly IProductRepository _productRepository;
    
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetALlAsync();
        }
    }
}