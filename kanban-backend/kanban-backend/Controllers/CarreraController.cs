using kanban_backend.Application.Dtos;
using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarreraController : ControllerBase
    {
        private readonly CarreraService _service;

        public CarreraController(CarreraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carrera = await _service.GetByIdAsync(id);
            if (carrera == null) return NotFound();
            return Ok(carrera);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarreraDTO carrera)
        {
            var creada = await _service.CreateAsync(carrera);
            return CreatedAtAction(nameof(Get), new { id = creada.Id }, creada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Carrera carrera)
        {
            if (id != carrera.Id) return BadRequest();
            await _service.UpdateAsync(carrera);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var resultados = await _service.SearchByNameAsync(name);
            return Ok(resultados);
        }
    }
}