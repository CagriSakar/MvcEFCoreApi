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
    public class CategoryService
    {
        private readonly AppDbContext _context;

        private readonly GenericRepository<Category> categoryRepository;


        private readonly UnitOfWork unitofwork;

        public CategoryService(AppDbContext context, GenericRepository<Category> categoryRepository,  UnitOfWork unitofwork)
        {
            _context = context;
            this.categoryRepository = categoryRepository;
            this.unitofwork = unitofwork;
        }

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryDtos = categories.Select(p => new CategoryDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            if (!categoryDtos.Any())//productDtos.any data yoksa false geliyor. ! ile onu true yapıyoruz ve if e giriyor.
            {
                return new Response<List<CategoryDto>>()
                {
                    Data = categoryDtos,
                    Errors = new List<string>() { "Kategori mevcut değil." },
                    Status = 404,
                };
            }

            return new Response<List<CategoryDto>>()
            {
                Data = categoryDtos,
                Errors = null,
                Status = 200,
            };
        }


        public async Task<Response<string>> CreateAll(Category catergory, Product product, ProductFeature productFeature)
        {
            await categoryRepository.Add(catergory);

            await unitofwork.Commit();

            return new Response<string>();
        }
    }
}
