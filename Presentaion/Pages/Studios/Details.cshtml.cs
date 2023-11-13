using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Studios;

public class DetailsModel : PageModel
{
    private readonly IStudioService _studioService;

    public DetailsModel(IStudioService studioService)
    {
        _studioService = studioService;
    }

    public Studio Studio { get; set; } = default!;

    public IActionResult OnGet()
    {
        var accId = HttpContext.Session.GetString("AccountID");
        var id = new Guid(accId);
        var studio = _studioService.GetStudioByAccountId(id);
        if (studio == null)
            return NotFound();
        Studio = studio;
        return Page();
    }
}