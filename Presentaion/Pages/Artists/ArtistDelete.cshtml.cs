using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists;

public class ArtistDeleteModel : PageModel
{
    private readonly IArtistService _artistService;

    public ArtistDeleteModel(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [BindProperty] public Artist Artist { get; set; }

    public IActionResult OnGet(Guid id)
    {
        if (id == null) return NotFound();

        Artist = _artistService.GetArtistById(id);

        if (Artist == null) return NotFound();
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        if (id == null) return NotFound();

        //Artist = _artistService.GetArtistById(id);

        if (Artist != null) _artistService.DeleteArtist(id);

        return RedirectToPage("./ArtistManager");
    }
}