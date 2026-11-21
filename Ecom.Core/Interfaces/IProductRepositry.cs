using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Core.Interfaces
{
    public interface IProductRepositry : IGenericRepositry<Product>
    {
        Task<bool> AddAsync(AddProductDTO productDto);
        Task<bool> UpdateAsync(UpdateProductDTO productDto);
    }
}
