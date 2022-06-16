using Microsoft.AspNetCore.Mvc;
using NLayer.Data.Models;
using NLayer.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeaturesController :ControllerBase
    {
        private readonly ProductFeatureService _productFeatureService;

        public ProductFeaturesController(ProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }

        /// <summary>Ürün Özelliği</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productFeatureService.GetAll();
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        /// <summary>Ürün Özelliği ID</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int productId)
        {
            return await Get(productId);
        }

        /// <summary>Ürün Özelliği kaydet</summary>
        [HttpPost]
        public async Task<IActionResult> Save(ProductFeature product)
        {
            return await Save(product);
        }

        /// <summary>Ürün Özelliği güncelle</summary>
        [HttpPut]
        public async Task<IActionResult> Update(ProductFeature product)
        {
            return await Update(product);
        }

        /// <summary>Ürün Özelliği sil</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int productId)
        {
            return await Delete(productId);
        }
    }
}
