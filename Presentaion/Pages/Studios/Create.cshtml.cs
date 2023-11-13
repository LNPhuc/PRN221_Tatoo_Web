using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Studios;

public class CreateModel : PageModel
{
    private readonly IStudioService _studioService;

    public CreateModel(IStudioService studioService)
    {
        _studioService = studioService;
    }

    [BindProperty] public Studio Studio { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public IActionResult OnPost()
    {
        _studioService.Create(Studio);

        return RedirectToPage("./Index");
    }
}