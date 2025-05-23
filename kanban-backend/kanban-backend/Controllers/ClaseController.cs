
using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaseController : ControllerBase
    {
        private readonly ClaseService _claseService;

        public ClaseController(ClaseService claseService)
        {
            _claseService = claseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clases = await _claseService.GetAllAsync();
            return Ok(clases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clase = await _claseService.GetByIdAsync(id);
            if (clase == null) return NotFound();
            return Ok(clase);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clase clase)
        {
            var newClase = await _claseService.CreateAsync(clase);
            return CreatedAtAction(nameof(GetById), new { id = newClase.Id }, newClase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Clase clase)
        {
            if (id != clase.Id) return BadRequest();
            await _claseService.UpdateAsync(clase);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _claseService.DeleteAsync(id);
            return NoContent();
        }
    }
}