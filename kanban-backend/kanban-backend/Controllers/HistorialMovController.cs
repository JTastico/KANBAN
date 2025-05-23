using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialDeMovimientoController : ControllerBase
    {
        private readonly HistorialMovService _service;

        public HistorialDeMovimientoController(HistorialMovService service)
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
            var historial = await _service.GetByIdAsync(id);
            if (historial == null) return NotFound();
            return Ok(historial);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistorialDeMovimiento historial)
        {
            var creado = await _service.CreateAsync(historial);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HistorialDeMovimiento historial)
        {
            if (id != historial.Id) return BadRequest();
            await _service.UpdateAsync(historial);
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