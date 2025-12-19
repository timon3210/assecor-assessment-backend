using Microsoft.AspNetCore.Mvc;

namespace AssecorAssessment.Controllers;

[ApiController]
[Route("persons")]
public class PersonsController : ControllerBase
{
    private readonly IPersonService _service;

    public PersonsController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _service.GetById(id);
        return person != null ? Ok(person) : NotFound();
    }

    [HttpGet("color/{color}")]
    public IActionResult GetByColor(string color)
    {
        return Ok(_service.GetByColor(color));
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] Person person)
    {
        if (person == null)
        {
            return BadRequest();
        }
        _service.Add(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }
}