using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Artists
{
    public class ArtistManagerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        private readonly IArtistService _artistService;
        private readonly IStudioService _studioService;

		public ArtistManagerModel(IArtistService artistService, IStudioService studioService)
		{
			_artistService = artistService;
			_studioService = studioService;
		}

		public List<Artist> Artists { get; set; } = default;
        public IActionResult OnGet()
        {
            try
            {
                var accId = HttpContext.Session.GetString("AccountID");
                Guid id = Guid.Parse(accId);
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
}
