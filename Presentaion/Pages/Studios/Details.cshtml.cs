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

namespace Presentaion.Pages.Studios
{
    public class DetailsModel : PageModel
    {
        private readonly IStudioService _studioService;

        public DetailsModel(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public Studio Studio { get; set; } = default!; 

        public IActionResult OnGet(Guid id)
        {

            var studio =  _studioService.GetById(id);
            if (studio == null)
            {
                return NotFound();
            }
            else 
            {
                Studio = studio;
            }
            return Page();
        }
    }
}
