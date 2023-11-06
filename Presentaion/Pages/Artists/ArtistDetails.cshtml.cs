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
    public class ArtistDetailsModel : PageModel
    {
        private readonly IArtistService _artistService;

        public ArtistDetailsModel(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public Artist Artist { get; set; }

        public IActionResult OnGet(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = _artistService.GetArtistById(id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
