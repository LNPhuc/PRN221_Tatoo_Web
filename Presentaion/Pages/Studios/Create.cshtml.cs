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

namespace Presentaion.Pages.Studios
{
    public class CreateModel : PageModel
    {
        private readonly IStudioService _studioService;

        public CreateModel(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          _studioService.Create(Studio);

            return RedirectToPage("./Index");
        }
    }
}
