using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Data.Models;
using NLayer.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>Ürün </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAll();
            return new ObjectResult(response) { StatusCode= response.Status };
        }

        /// <summary>Ürün  ID</summary>
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            return await Get(productId);
        }

        /// <summary>Ürün Kaydet</summary>
        [HttpPost]
        public async Task<IActionResult> Save(Product product)
        {
            return await Save(product);
        }

        /// <summary>Ürün Güncelle</summary>
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            return await Update(product);
        }

        /// <summary>Ürün sil</summary>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            return await Delete(productId);
        }
    }
}
