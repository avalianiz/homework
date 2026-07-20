using FluentValidation;
using homework14.Models;
using homework14.Services;
using Microsoft.AspNetCore.Mvc;

namespace homework14.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IPersonFileService _personService;
    private readonly IValidator<Person> _validator;

    public PersonsController(
        IPersonFileService personService,
        IValidator<Person> validator
    )
    {
        _personService = personService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAll(
        [FromQuery] string? city,
        [FromQuery] double? minSalary
    )
    {
        List<Person> persons = await _personService.GetAllAsync();

        IEnumerable<Person> filteredPersons = persons;

        if (!string.IsNullOrWhiteSpace(city))
        {
            filteredPersons = filteredPersons.Where(person =>
                person.PersonAddress is not null &&
                person.PersonAddress.City.Equals(
                    city,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        if (minSalary.HasValue)
        {
            filteredPersons = filteredPersons.Where(person =>
                person.Salary >= minSalary.Value
            );
        }

        return Ok(filteredPersons.ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetById(int id)
    {
        List<Person> persons = await _personService.GetAllAsync();

        if (id < 0 || id >= persons.Count)
        {
            return NotFound(new
            {
                message = $"Person with index {id} was not found."
            });
        }

        return Ok(persons[id]);
    }

    [HttpPost]
    public async Task<ActionResult<List<Person>>> Create(
        [FromBody] Person person
    )
    {
        var validationResult = await _validator.ValidateAsync(person);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                message = "Validation failed.",
                errors = validationResult.Errors.Select(error => new
                {
                    field = error.PropertyName,
                    message = error.ErrorMessage
                })
            });
        }

        List<Person> updatedPersons =
            await _personService.AddAsync(person);

        return Ok(updatedPersons);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<List<Person>>> Replace(
        int id,
        [FromBody] Person person
    )
    {
        var validationResult = await _validator.ValidateAsync(person);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                message = "Validation failed.",
                errors = validationResult.Errors.Select(error => new
                {
                    field = error.PropertyName,
                    message = error.ErrorMessage
                })
            });
        }

        List<Person>? updatedPersons =
            await _personService.ReplaceAsync(id, person);

        if (updatedPersons is null)
        {
            return NotFound(new
            {
                message = $"Person with index {id} was not found."
            });
        }

        return Ok(updatedPersons);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<List<Person>>> Delete(int id)
    {
        List<Person>? updatedPersons =
            await _personService.DeleteAsync(id);

        if (updatedPersons is null)
        {
            return NotFound(new
            {
                message = $"Person with index {id} was not found."
            });
        }

        return Ok(updatedPersons);
    }
}