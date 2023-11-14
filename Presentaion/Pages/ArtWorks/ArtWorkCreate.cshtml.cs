using BusinessLogic.DTOS.Artwork;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentaion.Pages.ArtWorks;

public class ArtWorkCreateModel : PageModel
{
    private readonly IArtistService _artistService;
    private readonly IArtworkService _artworkService;
    private readonly IStudioService _studioService;

    public ArtWorkCreateModel(IArtworkService artworkService, IStudioService studioService,
        IArtistService artistService)
    {
        _artworkService = artworkService;
        _studioService = studioService;
        _artistService = artistService;
    }

    [BindProperty] public CreateArtwork ArtWork { get; set; }

    public List<Artist> Artists { get; set; }
    public Artist Artist { get; set; }


    public IActionResult OnGet()
    { 
        var userName = HttpContext.Session.GetString("AccountID");
        var usernamid = Guid.Parse(userName);
        var studio = _studioService.GetStudioByAccountId(usernamid);
        Artists = _artistService.GetArtistByStudioId(studio.Id);
        ViewData["ArtistName"] = new SelectList(Artists, "Id", "Name");
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        /*ArtWork.ArtistId =*/


        _artworkService.CreateArtWork(ArtWork);


        return RedirectToPage("./ArtworkManager");
    }
}