using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Studios;

public class EditModel : PageModel
{
    private readonly IStudioService _studioService;

    public EditModel(IStudioService studioService)
    {
        _studioService = studioService;
    }

    [BindProperty] public Studio Studio { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        var accId = HttpContext.Session.GetString("AccountID");
        if (accId == null) return RedirectToPage("/LoginPage");

        var accountId = Guid.Parse(accId);
        Studio = _studioService.GetById(id);


        if (Studio.AccountId != accountId)
            return RedirectToPage("/LoginPage");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPost()
    {
        try
        {
            _studioService.Update(Studio.Id, Studio);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return Page();
    }
}