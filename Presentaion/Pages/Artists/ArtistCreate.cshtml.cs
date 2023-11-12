using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.DTOS.Artist;
using BusinessLogic.IService;

namespace Presentaion.Pages.Artists
{
    public class ArtistCreateModel : PageModel
    {
        private readonly IArtistService _artistService;
        private readonly IStudioService _studioService;

        public ArtistCreateModel(IArtistService artistService, IStudioService studioService)
        {
            _artistService = artistService;
            _studioService = studioService;
        }
        [BindProperty]
        public CreateArtist Artist { get; set; } = default!;
        public IActionResult OnGet()
        {

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userName = HttpContext.Session.GetString("AccountID");
            Guid usernameid = Guid.Parse(userName);
            var studio = _studioService.GetStudioByAccountId(usernameid);
            Artist.StudioId = studio.Id;
            _artistService.CreateArtist(Artist);

            return RedirectToPage("./ArtistManager");
        }
    }
}
