using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.ArtWork;

public class DeleteModel : PageModel
{
    private readonly IArtworkService _artworkService;

    public DeleteModel(IArtworkService artworkService)
    {
        _artworkService = artworkService;
    }

    [BindProperty] public DataAccess.DataAccess.ArtWork ArtWork { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        var artWork = _artworkService.GetArtWorkByID(id);

        if (artWork == null)
            return NotFound();
        ArtWork = artWork;
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        if (id == null) return NotFound();
        if (ArtWork != null) _artworkService.DeleteArtWork(ArtWork);

        return RedirectToPage("./ArtworkManager");
    }
}