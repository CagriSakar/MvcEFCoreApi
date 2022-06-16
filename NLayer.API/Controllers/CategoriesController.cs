using Microsoft.AspNetCore.Mvc;
using NLayer.Data.Models;
using NLayer.Service;

namespace NLayer.API.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>Kategoriler</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAll();
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        /// <summary>Kategori ID</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            return await Get(Id);
        }

        /// <summary>Kategori Kaydet</summary>
        [HttpPost]
        public async Task<IActionResult> Save(Category category)
        {
            return await Save(category);
        }

        /// <summary>Kategori güncelle</summary>
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            return await Update(category);
        }

        /// <summary>Kategori sil</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int productId)
        {
            return await Delete(productId);
        }
    }
}
