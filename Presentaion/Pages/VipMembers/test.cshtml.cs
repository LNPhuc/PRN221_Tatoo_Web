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

namespace Presentaion.Pages.VipMembers
{
    public class testModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public testModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VipMember VipMember { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VipMember = await _context.VipMembers
                .Include(v => v.Customer)
                .Include(v => v.Studio).FirstOrDefaultAsync(m => m.Id == id);

            if (VipMember == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
           ViewData["StudioId"] = new SelectList(_context.Studios, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VipMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VipMemberExists(VipMember.Id))
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

        private bool VipMemberExists(Guid id)
        {
            return _context.VipMembers.Any(e => e.Id == id);
        }
    }
}
