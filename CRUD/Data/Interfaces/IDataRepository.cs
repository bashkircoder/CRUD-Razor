using CRUD.Model;

namespace CRUD.Data.Interfaces;

public interface IDataRepository
{
    List<Person> GetAllPersons();
    
    Person GetPersonById(Guid id);
    
    void AddPerson(Person person);
    
    void UpdatePerson(Person person);
    
    void DeletePerson(Person person);

}