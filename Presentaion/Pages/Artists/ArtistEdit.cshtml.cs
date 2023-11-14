using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists;

public class ArtistEditModel : PageModel
{
    private readonly IArtistService _artistService;

    public ArtistEditModel(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [BindProperty] public Artist Artist { get; set; }

    public IActionResult OnGet(Guid id)
    {
        try
        {
            Artist = _artistService.GetArtistById(id);
            return Page();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return Page();
        }
    }

    public IActionResult OnPost()
    {
        try
        {
            Artist = _artistService.UdpateArtist(Artist.Id, Artist);
            return Redirect("/Artists/ArtistManager");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return Page();
    }
}