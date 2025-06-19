using CRUD.Data.Interfaces;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages;

public class Create(IDataRepository dataRepository) : PageModel
{
    [BindProperty] public Person? Person { get; set; }

    public void OnGet()
    {
        
    }
    
    public IActionResult OnPost()
    {
        Person.Id = Guid.NewGuid();
        
        dataRepository.AddPerson(Person);
        
        return RedirectToPage("./Index");
    }
}