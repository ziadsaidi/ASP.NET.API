using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        public CategoryResponse(bool success, string message,Category category) : base(success, message)
        {
            Category = category;
        }

          public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}