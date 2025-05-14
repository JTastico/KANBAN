
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        ICarreraRepository carreraRepository;
        public RoleController(ICarreraRepository carreraRepository)
        {
            this.carreraRepository = carreraRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await carreraRepository.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Carrera carrera)
        {
            return Ok(await carreraRepository.AddAsync(carrera));
        }
        
        
          
    }   
  
