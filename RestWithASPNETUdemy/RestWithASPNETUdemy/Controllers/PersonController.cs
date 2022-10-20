using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;


        public PersonController(ILogger<PersonController> logger,
                                IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var retorno = _personService.FindById(Id);
            if (retorno == null) return NotFound();
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var retorno = _personService.Create(person);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var retorno = _personService.Update(person);
            if (retorno == null) return BadRequest();
            return Ok(retorno);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
             _personService.Delete(Id);
            return NoContent();
        }

    }
}