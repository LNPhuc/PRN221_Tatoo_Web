using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;

namespace Presentaion.Pages.ArtWorks
{
    public class ArtWorkCreateModel : PageModel
    {
       private readonly IArtworkService _artworkService;

        public ArtWorkCreateModel(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        public IActionResult OnGet()
        {
       
            return Page();
        }

        [BindProperty]
        public DataAccess.DataAccess.ArtWork ArtWork { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _artworkService.CreateArtWork(ArtWork); 
          

            return RedirectToPage("./Index");
        }
    }
}
