using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _comentarioService;

        public ComentarioController(ComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comentarioService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comentario = await _comentarioService.GetByIdAsync(id);
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comentario comentario)
        {
            var nuevo = await _comentarioService.CreateAsync(comentario);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comentario comentario)
        {
            if (id != comentario.Id) return BadRequest();
            await _comentarioService.UpdateAsync(comentario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _comentarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}