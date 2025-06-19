using CRUD.Data.Interfaces;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages;

public class Delete(IDataRepository dataRepository) : PageModel
{
    [BindProperty] public Person Person { get; set; }
    [BindProperty] public bool toDelete { get; set; } =  false;
    
    public void OnGet(Guid id)
    {
        Person = dataRepository.GetPersonById(id);
    }

    public IActionResult OnPost(Person person)
    {
        if (toDelete)
        {
            dataRepository.DeletePerson(Person);
        }
        
        return RedirectToPage("./Index");
    }
}