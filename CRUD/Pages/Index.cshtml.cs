using CRUD.Data.Interfaces;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages;

public class IndexModel(IDataRepository dataRepository) : PageModel
{
    [BindProperty] public List<Person> Persons { get; set; } = [];
    
    public void OnGet()
    {
        Persons = dataRepository.GetAllPersons();
    }

    public void Update()
    {
    }
}