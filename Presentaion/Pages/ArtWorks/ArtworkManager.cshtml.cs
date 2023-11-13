using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.ArtWorks;

public class ArtworkManagerModel : PageModel
{
    private readonly IArtworkService _artworkService;
    private readonly IStudioService _studioService;

    public ArtworkManagerModel(IArtworkService artworkService, IStudioService studioService)
    {
        _artworkService = artworkService;
        _studioService = studioService;
    }

    public List<DataAccess.DataAccess.ArtWork> ArtWork { get; set; } = default!;

    [BindProperty] public string ArtWorkName { get; set; } = default!;

    public IActionResult OnGet()
    {
        var accId = HttpContext.Session.GetString("AccountID");
        var id = new Guid(accId);
        var stu = _studioService.GetStudioByAccountId(id);
        ArtWork = _artworkService.getAllawByStuId(stu.Id);
        return Page();
    }
}