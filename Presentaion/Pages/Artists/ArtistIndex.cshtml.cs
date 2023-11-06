using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists
{
    public class ArtistIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        private readonly IArtistService _artistService;

        public ArtistIndexModel(IArtistService artistService)
        {
            _artistService = artistService;
        }
        public List<Artist> Artists { get; set; } = default;
        public IActionResult OnGet()
        {
            Artists = _artistService.SearchArtist(SearchQuery);
            return Page();
        }
    }
}
