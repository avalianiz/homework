using homework17.Data;
using homework17.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework17.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public PersonsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Person>>> Create(Person person)
    {
        _dbContext.Persons.Add(person);
        await _dbContext.SaveChangesAsync();

        return Ok(await _dbContext.Persons.Include(p => p.PersonAddress).ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        return Ok(await _dbContext.Persons.Include(p => p.PersonAddress).ToListAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Person>> GetById(Guid id)
    {
        var person = await _dbContext.Persons
            .Include(p => p.PersonAddress)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Person>>> Filter(
        [FromQuery] string? city,
        [FromQuery] double? minSalary)
    {
        var query = _dbContext.Persons.Include(p => p.PersonAddress).AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
            query = query.Where(p => p.PersonAddress.City == city);

        if (minSalary.HasValue)
            query = query.Where(p => p.Salary >= minSalary.Value);

        return Ok(await query.ToListAsync());
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<Person>>> Delete(Guid id)
    {
        var person = await _dbContext.Persons.FindAsync(id);

        if (person == null)
            return NotFound();

        _dbContext.Persons.Remove(person);
        await _dbContext.SaveChangesAsync();

        return Ok(await _dbContext.Persons.Include(p => p.PersonAddress).ToListAsync());
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<Person>>> Update(Guid id, Person updatedPerson)
    {
        var person = await _dbContext.Persons
            .Include(p => p.PersonAddress)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (person == null)
            return NotFound();

        person.CreateDate = updatedPerson.CreateDate;
        person.FirstName = updatedPerson.FirstName;
        person.LastName = updatedPerson.LastName;
        person.JobPosition = updatedPerson.JobPosition;
        person.Salary = updatedPerson.Salary;
        person.WorkExperience = updatedPerson.WorkExperience;

        person.PersonAddress.City = updatedPerson.PersonAddress.City;
        person.PersonAddress.Country = updatedPerson.PersonAddress.Country;
        person.PersonAddress.HomeNumber = updatedPerson.PersonAddress.HomeNumber;

        await _dbContext.SaveChangesAsync();

        return Ok(person);
    }
}
