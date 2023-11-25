using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SportShop_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var clients = await service.GetAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await service.GetAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditClientModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.EditAsync(model);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);

            return Ok();
        }
    }
}
