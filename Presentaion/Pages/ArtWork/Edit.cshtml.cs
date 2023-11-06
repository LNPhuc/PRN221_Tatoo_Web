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

namespace Presentaion.Pages.ArtWork
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public EditModel(DataAccess.TatooWebContext context)
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

            var artwork =  await _context.ArtWorks.FirstOrDefaultAsync(m => m.Id == id);
            if (artwork == null)
            {
                return NotFound();
            }
            ArtWork = artwork;
           ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArtWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtWorkExists(ArtWork.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtWorkExists(Guid id)
        {
          return (_context.ArtWorks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
