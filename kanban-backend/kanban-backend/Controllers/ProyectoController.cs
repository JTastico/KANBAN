using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoService _service;

        public ProyectoController(ProyectoService service)
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
            var proyecto = await _service.GetByIdAsync(id);
            if (proyecto == null) return NotFound();
            return Ok(proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Proyecto proyecto)
        {
            var creado = await _service.CreateAsync(proyecto);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Proyecto proyecto)
        {
            if (id != proyecto.Id) return BadRequest();
            await _service.UpdateAsync(proyecto);
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