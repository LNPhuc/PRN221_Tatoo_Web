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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public DeleteModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DataAccess.DataAccess.ArtWork ArtWork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ArtWorks == null)
            {
                return NotFound();
            }

            var artwork = await _context.ArtWorks.FirstOrDefaultAsync(m => m.Id == id);

            if (artwork == null)
            {
                return NotFound();
            }
            else 
            {
                ArtWork = artwork;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ArtWorks == null)
            {
                return NotFound();
            }
            var artwork = await _context.ArtWorks.FindAsync(id);

            if (artwork != null)
            {
                ArtWork = artwork;
                _context.ArtWorks.Remove(ArtWork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
