using Microsoft.EntityFrameworkCore;
using NLayer.Data;
using NLayer.Data.Models;
using NLayer.Service.Dtos;
using NLayer.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        private readonly GenericRepository<Product> productRepository;
        private readonly GenericRepository<Category> categoryRepository;
        private readonly GenericRepository<ProductFeature> productFeatureRepository;


        private readonly UnitOfWork unitofwork;

        public ProductService(AppDbContext context, GenericRepository<Product> productRepository, GenericRepository<Category> categoryRepository, GenericRepository<ProductFeature> productFeatureRepository, UnitOfWork unitofwork)
        {
            _context = context;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productFeatureRepository = productFeatureRepository;
            this.unitofwork = unitofwork;
        }

        public async Task<Response<List<ProductDto>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            var productDtos = products.Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                }).ToList();

            if(!productDtos.Any())//productDtos.any data yoksa false geliyor. ! ile onu true yapıyoruz ve if e giriyor.
            {
                return new Response<List<ProductDto>>()
                {
                    Data = productDtos,
                    Errors = new List<string>() { "ürün mevcut değildir" },
                    Status = 404,
                };
            }

            return new Response<List<ProductDto>>()
            {
                Data = productDtos,
                Errors = null,
                Status = 200,
            };
        }


        public async Task<Response<string>> CreateAll(Category catergory, Product product, ProductFeature productFeature)
        {
            await categoryRepository.Add(catergory);
            await productRepository.Add(product);
            await productFeatureRepository.Add(productFeature);

            await unitofwork.Commit();

            return new Response<string>();
        }

    }
}
