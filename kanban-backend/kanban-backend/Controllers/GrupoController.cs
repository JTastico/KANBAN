using kanban_backend.Application.Dtos;
using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _service;

        public GrupoController(GrupoService grupoService)
        {
            _service = grupoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var grupo = await _service.GetByIdAsync(id);
            if (grupo == null) return NotFound();
            return Ok(grupo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrupoDTO grupo)
        {
            var nuevo = await _service.CreateAsync(grupo);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Grupo grupo)
        {
            if (id != grupo.Id) return BadRequest();
            await _service.UpdateAsync(grupo);
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