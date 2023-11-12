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

namespace Presentaion.Pages.ArtWork
{
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
            if (id == null)
            {
                return NotFound();
            }

            var artwork = _artworkService.GetArtWorkByID(id);
            if (artwork == null)
            {
                return NotFound();
            }
            else
            {
                ArtWork = artwork;
            }
            return Page();
        }
    }
}
