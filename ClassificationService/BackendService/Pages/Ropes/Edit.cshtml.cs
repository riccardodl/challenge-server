using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ropes
{
    public class EditModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public EditModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rope Rope { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rope = await _context.Rope
                .Include(r => r.Ship).FirstOrDefaultAsync(m => m.RopeID == id);

            if (Rope == null)
            {
                return NotFound();
            }
           ViewData["ShipID"] = new SelectList(_context.Ship, "ShipID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rope).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RopeExists(Rope.RopeID))
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

        private bool RopeExists(int id)
        {
            return _context.Rope.Any(e => e.RopeID == id);
        }
    }
}
