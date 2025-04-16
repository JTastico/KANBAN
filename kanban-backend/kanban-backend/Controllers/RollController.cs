
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
        
          
        [HttpPost( "{num1}")]

        public IActionResult Post([FromRoute]int num1, [FromBody]int num2)
        {
            return Ok(num1+num2);
        }
    }   
  
