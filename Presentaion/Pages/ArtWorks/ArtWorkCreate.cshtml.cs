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
using BusinessLogic.Service;
using BusinessLogic.DTOS.Artwork;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Pages.ArtWorks
{
    public class ArtWorkCreateModel : PageModel
    {
       private readonly IArtworkService _artworkService;
       private readonly IStudioService _studioService;
       private readonly IArtistService _artistService;

        public ArtWorkCreateModel(IArtworkService artworkService , IStudioService studioService , IArtistService artistService)
        {
            _artworkService = artworkService;
            _studioService = studioService;
            _artistService = artistService;
        }
        

        public IActionResult OnGet()
        {
            var userName = HttpContext.Session.GetString("AccountID");
            Guid usernamid = Guid.Parse(userName);
            var studio = _studioService.GetStudioByAccountId(usernamid);
            Artists = _artistService.GetArtistByStudioId(studio.Id);
            ViewData["ArtistId"] = new SelectList(Artists, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CreateArtwork ArtWork { get; set; }
        public List<Artist> Artists { get; set; }
        public Artist Artist { get; set; }  

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            /*ArtWork.ArtistId =*/

            


            _artworkService.CreateArtWork(ArtWork);



            return RedirectToPage("./ArtworkManager");
        }
    }
}
