using homework14.Models;

namespace homework14.Services;

public interface IPersonFileService
{
    Task<List<Person>> GetAllAsync();
    Task<List<Person>> AddAsync(Person person);
    Task<List<Person>> DeleteAsync(int id);
    Task<List<Person>> ReplaceAsync(int id, Person person);
}