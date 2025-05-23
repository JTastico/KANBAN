using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _service;

        public PersonaController(PersonaService service)
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
            var persona = await _service.GetByIdAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Persona persona)
        {
            var creada = await _service.CreateAsync(persona);
            return CreatedAtAction(nameof(Get), new { id = creada.Id }, creada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id) return BadRequest();
            await _service.UpdateAsync(persona);
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