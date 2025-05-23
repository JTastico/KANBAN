using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly TareasService _service;

        public TareasController(TareasService service)
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
            var tarea = await _service.GetByIdAsync(id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tareas tarea)
        {
            var creada = await _service.CreateAsync(tarea);
            return CreatedAtAction(nameof(Get), new { id = creada.Id }, creada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tareas tarea)
        {
            if (id != tarea.Id) return BadRequest();
            await _service.UpdateAsync(tarea);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}