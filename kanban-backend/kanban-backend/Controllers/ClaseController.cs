
using kanban_backend.Application.Dtos;
using kanban_backend.Application.Services;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaseController : ControllerBase
    {
        private readonly ClaseService _service;

        public ClaseController(ClaseService claseService)
        {
            _service = claseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clases = await _service.GetAllAsync();
            return Ok(clases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clase = await _service.GetByIdAsync(id);
            if (clase == null) return NotFound();
            return Ok(clase);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClaseDTO clase)
        {
            var newClase = await _service.CreateAsync(clase);
            return CreatedAtAction(nameof(GetById), new { id = newClase.Id }, newClase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Clase clase)
        {
            if (id != clase.Id) return BadRequest();
            await _service.UpdateAsync(clase);
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