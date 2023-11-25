using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportShop_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var employees = await service.GetAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await service.GetAsync(id);
            if(employee == null) { return NotFound(); }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await service.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditEmployeeModel model)
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
