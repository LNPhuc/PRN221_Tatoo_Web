using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists;

public class ArtistIndexModel : PageModel
{
    private readonly IArtistService _artistService;

    public ArtistIndexModel(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    public List<Artist> Artists { get; set; }

    public IActionResult OnGet()
    {
        Artists = _artistService.SearchArtist(SearchQuery);
        return Page();
    }
}