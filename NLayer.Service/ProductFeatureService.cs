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
    public class ProductFeatureService
    {
        private readonly AppDbContext _context;

        private readonly GenericRepository<ProductFeature> productFeatureRepository;


        private readonly UnitOfWork unitofwork;

        public ProductFeatureService(AppDbContext context, GenericRepository<ProductFeature> productFeatureRepository, UnitOfWork unitofwork)
        {
            _context = context;
            this.productFeatureRepository = productFeatureRepository;
            this.unitofwork = unitofwork;
        }

        public async Task<Response<List<Dtos.ProductFeatureDto>>> GetAll()
        {
            var productFeatures = await _context.ProductFeatures.ToListAsync();

            var productFeatureDtos = productFeatures.Select(p => new ProductFeatureDto()
            {
                Id = p.Id,
                Width = p.Width,
                Height = p.Height,
                
            }).ToList();

            if (!productFeatureDtos.Any())//productDtos.any data yoksa false geliyor. ! ile onu true yapıyoruz ve if e giriyor.
            {
                return new Response<List<ProductFeatureDto>>()
                {
                    Data = productFeatureDtos,
                    Errors = new List<string>() { "ürün özelliği mevcut değil" },
                    Status = 404,
                };
            }

            return new Response<List<ProductFeatureDto>>()
            {
                Data = productFeatureDtos,
                Errors = null,
                Status = 200,
            };
        }


        public async Task<Response<string>> CreateAll(Category catergory, Product product, ProductFeature productFeature)
        {
            await productFeatureRepository.Add(productFeature);

            await unitofwork.Commit();

            return new Response<string>();
        }

    }
}
