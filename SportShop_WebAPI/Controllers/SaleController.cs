using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportShop_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService service;

        public SaleController(ISaleService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var sales = await service.GetAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await service.GetAsync(id);
            if(sale == null) { return NotFound(); }
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditSaleModel model)
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
