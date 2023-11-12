using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentaion.Pages.ArtWork
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public IndexModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        public IList<DataAccess.DataAccess.ArtWork> ArtWork { get; set; } = default!;
        [BindProperty]
        public string ArtWorkName { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (ArtWork == null)
            {
                ArtWork = await _context.ArtWorks
                .Include(a => a.Artist).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(string title)
        {
            title = ArtWorkName;
            ArtWork = await _context.ArtWorks.Include(a => a.Artist).Where(c => c.Title.Equals(title)).ToListAsync();
            return Page();
        }
    }
}
