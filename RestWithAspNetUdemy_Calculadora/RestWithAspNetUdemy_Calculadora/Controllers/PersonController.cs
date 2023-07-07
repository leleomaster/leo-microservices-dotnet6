using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy_Calculadora.Model;
using RestWithAspNetUdemy_Calculadora.Services;

namespace RestWithAspNetUdemy_Calculadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<CalculatorController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindId(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personService.Update(person));
        }
    }

}