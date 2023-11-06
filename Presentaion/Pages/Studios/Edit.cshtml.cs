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

namespace Presentaion.Pages.Studios
{
    public class EditModel : PageModel
    {
        private readonly IStudioService _studioService;

        public EditModel(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;

        public IActionResult OnGet(Guid id)
        {

            Studio = _studioService.GetById(id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            
            try
            {
                _studioService.Update(Studio.Id, Studio);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }

        
    }
}
