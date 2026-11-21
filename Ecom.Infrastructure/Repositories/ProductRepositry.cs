using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrastructure.Repositories
{
    public class ProductRepositry : GenericRepositry<Product>, IProductRepositry
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        private readonly IImageMangmentService _imageMangmentService;
        public ProductRepositry(AppDbContext context, IMapper mapper, IImageMangmentService imageMangmentService) : base(context)
        {
            _context = context;
            this.mapper = mapper;
            _imageMangmentService = imageMangmentService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDto)
        {
            if (productDto == null)
                return false;
            var product = mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            var imagePath =await _imageMangmentService.UploadImagesAsync(productDto.Photo, productDto.Name);
            var photo =  imagePath.Select(path => new Photo { ImageName = path, ProductId = product.Id }).ToList();
            await _context.Photos.AddRangeAsync(photo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateProductDTO productDto)
        {
            if (productDto == null)
                return false;
            var product = await _context.Products.Include(m=>m.Categories)
                                                 .Include(m=>m.Photos)
                                                 .FirstOrDefaultAsync(m=>m.Id == productDto.Id);
            if (product == null)
                return false;
            mapper.Map(productDto, product);
            var findPhoto = await _context.Photos.Where(m => m.ProductId == productDto.Id).ToListAsync();
            foreach (var item in findPhoto)
            {
                _imageMangmentService.DeleteImageAsync(item.ImageName);
            }
            _context.Photos.RemoveRange(findPhoto);
            var imagePath = await _imageMangmentService.UploadImagesAsync(productDto.Photo, productDto.Name);
            var photo = imagePath.Select(path => new Photo { ImageName = path, ProductId = product.Id }).ToList();
            await _context.Photos.AddRangeAsync(photo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
