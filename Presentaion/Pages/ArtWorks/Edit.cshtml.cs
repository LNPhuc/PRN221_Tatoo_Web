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
using BusinessLogic.Service;

namespace Presentaion.Pages.ArtWork
{
    public class EditModel : PageModel
    {
        private readonly IArtworkService _artworkService;
        private readonly IStudioService _studioService;
        private readonly IArtistService _artistService;

        public EditModel(IArtworkService artworkService, IStudioService studioService, IArtistService artistService)
        {
            _artworkService = artworkService;
            _studioService = studioService;
            _artistService = artistService;
        }

        [BindProperty]
        public DataAccess.DataAccess.ArtWork ArtWork { get; set; } = default!;
        [BindProperty]
        public List<Artist> Artists { get; set; }

        public IActionResult OnGet(Guid id)
        {

            var userName = HttpContext.Session.GetString("AccountID");
            Guid usernamid = Guid.Parse(userName);
            var studio = _studioService.GetStudioByAccountId(usernamid);
            Artists = _artistService.GetArtistByStudioId(studio.Id);
            ViewData["ArtistId"] = new SelectList(Artists, "Id", "Name");
            try
            {
                var artWork = _artworkService.GetArtWorkByID(id);
                if (artWork == null)
                {
                    return NotFound();
                }
                ArtWork = artWork;
                /*ViewData["ArtistId"] = ArtWork.Id;*/
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();

            }


        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {

            var userName = HttpContext.Session.GetString("AccountID");
            Guid usernamid = Guid.Parse(userName);
            var studio = _studioService.GetStudioByAccountId(usernamid);
            Artists = _artistService.GetArtistByStudioId(studio.Id);
            ViewData["ArtistId"] = new SelectList(Artists, "Id", "Name");

            try
            {
                //ViewData["ArtistId"] = new SelectList(Artists, "Id", "Id");

                _artworkService.UpdateArtWork(ArtWork.Id, ArtWork);
                return RedirectToPage("./ArtworkManager");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                //ViewData["ArtistId"] = new SelectList(Artists, "Id", "Id");


            }

            return Page();
        }

    }
}
