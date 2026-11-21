using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageMangmentService _imageMangmentService;
        public IProductRepositry ProductRepositry { get; }
        public ICategoryRepositry CategoryRepositry { get; }
        public IPhotoRepositry PhotoRepositry { get; }
        
        public UnitOfWork(AppDbContext context, IMapper mapper, IImageMangmentService imageMangmentService)
        {
            _context = context;
            _mapper = mapper;
            _imageMangmentService = imageMangmentService;
            CategoryRepositry = new CategoryRepositry(_context);
            ProductRepositry = new ProductRepositry(_context, _mapper, _imageMangmentService);
            PhotoRepositry = new PhotoRepositry(_context);
        }
    }
}
