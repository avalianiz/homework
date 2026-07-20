using System.Text.Json;
using homework14.Models;

namespace homework14.Services;


public class PersonFileService : IPersonFileService
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _fileLock = new(1, 1);

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public PersonFileService(IWebHostEnvironment environment)
    {
        string dataDirectory = Path.Combine(
            environment.ContentRootPath,
            "Data"
        );

        Directory.CreateDirectory(dataDirectory);

        _filePath = Path.Combine(dataDirectory, "persons.json");

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    public async Task<List<Person>> GetAllAsync()
    {
        await _fileLock.WaitAsync();

        try
        {
            return await ReadFromFileAsync();
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<List<Person>> AddAsync(Person person)
    {
        await _fileLock.WaitAsync();

        try
        {
            List<Person> persons = await ReadFromFileAsync();

            persons.Add(person);

            await WriteToFileAsync(persons);

            return persons;
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<List<Person>?> DeleteAsync(int id)
    {
        await _fileLock.WaitAsync();

        try
        {
            List<Person> persons = await ReadFromFileAsync();

            if (id < 0 || id >= persons.Count)
            {
                return null;
            }

            persons.RemoveAt(id);

            await WriteToFileAsync(persons);

            return persons;
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<List<Person>?> ReplaceAsync(
        int id,
        Person person
    )
    {
        await _fileLock.WaitAsync();

        try
        {
            List<Person> persons = await ReadFromFileAsync();

            if (id < 0 || id >= persons.Count)
            {
                return null;
            }

            persons[id] = person;

            await WriteToFileAsync(persons);

            return persons;
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<Person>> ReadFromFileAsync()
    {
        string json = await File.ReadAllTextAsync(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return [];
        }

        return JsonSerializer.Deserialize<List<Person>>(
                   json,
                   _jsonOptions
               )
               ?? [];
    }

    private async Task WriteToFileAsync(List<Person> persons)
    {
        string json = JsonSerializer.Serialize(
            persons,
            _jsonOptions
        );

        await File.WriteAllTextAsync(_filePath, json);
    }
}