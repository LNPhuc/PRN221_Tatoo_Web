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
using BusinessLogic.Service;

namespace Presentaion.Pages.Studios
{
    public class IndexModel : PageModel
    {
        
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        private readonly IStudioService _studioService;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        [BindProperty] public string? NewId { get; set; }
        public IndexModel(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public List<Studio> Studio { get;set; } = default!;

        public IActionResult OnGet()
        {

			var stu = _studioService.Search(SearchQuery, PageIndex - 1, PageSize);
            TotalPages = stu.TotalPagesCount;
            Studio = stu.Items.ToList();
            return Page();
        }

    }
}
