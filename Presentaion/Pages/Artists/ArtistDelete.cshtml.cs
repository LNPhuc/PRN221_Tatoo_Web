using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;

namespace Presentaion.Pages.Artists
{
    public class ArtistDeleteModel : PageModel
    {
        private readonly IArtistService _artistService;

        public ArtistDeleteModel(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [BindProperty]
        public Artist Artist { get; set; }

        public IActionResult OnGet(Guid id)
        {

            var artist = _artistService.GetArtistById(id);

            if (artist == null)
            {
                return NotFound();
            }
            else
            {
                Artist = artist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            _artistService.DeleteArtist(id);

            return RedirectToPage("./ArtistManager");
        }
    }
}
