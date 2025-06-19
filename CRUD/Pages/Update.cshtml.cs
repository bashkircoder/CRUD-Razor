using CRUD.Data.Interfaces;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages;

public class Update(IDataRepository dataRepository) : PageModel
{
    [BindProperty]
    public Person? person { get; set; }
    
    public void OnGet(Guid id)
    {
        person = dataRepository.GetPersonById(id);
        
    }

    public IActionResult OnPost()
    {
        dataRepository.UpdatePerson(person);
        
        return RedirectToPage("./Index");
    }
}