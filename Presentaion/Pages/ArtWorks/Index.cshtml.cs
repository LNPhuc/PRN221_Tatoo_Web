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
    public class IndexModel : PageModel
    {
        private readonly IArtworkService _artworkService;

        public IndexModel(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        public List<DataAccess.DataAccess.ArtWork> ArtWork { get; set; } = default!;
        [BindProperty]
        public string ArtWorkName { get; set; } = default!;

        public IActionResult OnGet()
        {
            ArtWork = _artworkService.getAllartwork();
            return Page();
        }


    }
}
