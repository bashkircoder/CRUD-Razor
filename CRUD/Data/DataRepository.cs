using System.Text.Json;
using CRUD.ConnectionString;
using CRUD.Data.Interfaces;
using CRUD.Model;
using Microsoft.Extensions.Options;

namespace CRUD.Data;

public class DataRepository(IOptions<FileConnection> options) : IDataRepository
{
    public List<Person> GetAllPersons()
    {
        var streamReader = new StreamReader(options.Value.ConnectionString);
        var file = streamReader.ReadToEnd();
        var persons = JsonSerializer.Deserialize<List<Person>?>(file);
        
        streamReader.Close();
        
        return persons ?? [];
    }

    public Person GetPersonById(Guid id)
    {
        var streamReader = new StreamReader(options.Value.ConnectionString);
        var file = streamReader.ReadToEnd();
        var persons = JsonSerializer.Deserialize<List<Person>>(file);
        
        streamReader.Close();

        var person = persons.FirstOrDefault(x => x.Id == id);

        if (person != null)
        {
            return person;
        }
        else
        {
            return new Person();
        }
    }

    public void AddPerson(Person person)
    {
        var streamReader = new StreamReader(options.Value.ConnectionString);
        var file = streamReader.ReadToEnd();
        var persons = JsonSerializer.Deserialize<List<Person>>(file);
        streamReader.Close();
        
        persons.Add(person);
        
        var streamWriter = new StreamWriter(options.Value.ConnectionString);
        var json = JsonSerializer.Serialize(persons);
        
        streamWriter.WriteLine(json);
        streamWriter.Close();
    }
    
    public void UpdatePerson(Person person)
    {
        var streamReader = new StreamReader(options.Value.ConnectionString);
        var file = streamReader.ReadToEnd();
        var persons = JsonSerializer.Deserialize<List<Person>>(file);
        streamReader.Close();
        
        var personToUpdate = persons.FirstOrDefault(x => x.Id == person.Id);
        
        personToUpdate.FirstName = person.FirstName;
        personToUpdate.LastName = person.LastName;
        personToUpdate.PhoneNumber = person.PhoneNumber;
        personToUpdate.Email = person.Email;
        
        
        var streamWriter = new StreamWriter(options.Value.ConnectionString);
        var json = JsonSerializer.Serialize(persons);
        
        streamWriter.WriteLine(json);
        streamWriter.Close();
    }
    public void DeletePerson(Person person)
    {
        var streamReader = new StreamReader(options.Value.ConnectionString);
        var file = streamReader.ReadToEnd();
        var persons = JsonSerializer.Deserialize<List<Person>>(file);
        streamReader.Close();
        
        var personToDelete = persons.FirstOrDefault(x => x.Id == person.Id);

        persons.Remove(personToDelete);
        
        var streamWriter = new StreamWriter(options.Value.ConnectionString);
        var json = JsonSerializer.Serialize(persons);
        
        streamWriter.WriteLine(json);
        streamWriter.Close();
    }
    
}