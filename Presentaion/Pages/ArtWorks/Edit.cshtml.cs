using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;

namespace Presentaion.Pages.ArtWork
{
    public class EditModel : PageModel
    {
       private readonly IArtworkService _artworkService;

        public EditModel(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [BindProperty]
        public DataAccess.DataAccess.ArtWork ArtWork { get; set; } = default!;

        public IActionResult OnGet(Guid id)
        {
            var artWork = _artworkService.GetArtWorkByID(id);
            if (artWork == null)
            {
                return NotFound();
            }
            ArtWork = artWork;
            ViewData["ArtistId"] = ArtWork.Id;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }         
            try
            {
               _artworkService.UpdateArtWork(ArtWork);
            }
            catch (Exception ex)
            {
                
                              
            }

            return RedirectToPage("./Index");
        }
      
    }
}
