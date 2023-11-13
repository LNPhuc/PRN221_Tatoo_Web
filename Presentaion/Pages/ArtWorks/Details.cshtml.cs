using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.ArtWork;

public class DetailsModel : PageModel
{
    private readonly IArtworkService _artworkService;

    public DetailsModel(IArtworkService artworkService)
    {
        _artworkService = artworkService;
    }

    public DataAccess.DataAccess.ArtWork ArtWork { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        if (id == null) return NotFound();

        var artwork = _artworkService.GetArtWorkByID(id);
        if (artwork == null)
            return NotFound();
        ArtWork = artwork;
        return Page();
    }
}