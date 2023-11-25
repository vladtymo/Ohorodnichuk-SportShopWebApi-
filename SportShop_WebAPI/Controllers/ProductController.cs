using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportShop_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var products = await service.GetAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await service.GetAsync(id);
            if(product == null) { return NotFound(); }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.EditAsync(model);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);

            return Ok();
        }
    }
}
