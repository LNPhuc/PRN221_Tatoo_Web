using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists;

public class ArtistManagerModel : PageModel
{
    private readonly IArtistService _artistService;
    private readonly IStudioService _studioService;

    public ArtistManagerModel(IArtistService artistService, IStudioService studioService)
    {
        _artistService = artistService;
        _studioService = studioService;
    }

    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    public List<Artist> Artists { get; set; }

    public IActionResult OnGet()
    {
        try
        {
            var accId = HttpContext.Session.GetString("AccountID");
            var id = Guid.Parse(accId);
            var stu = _studioService.GetStudioByAccountId(id);
            Artists = _artistService.GetArtistByStudioId(stu.Id);
            return Page();
        }
        catch (Exception ex)
        {
            return RedirectToPage("/LoginPage");
        }
    }
}