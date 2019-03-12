using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Broker.Models;

namespace Broker.Pages.Ropes
{
    public class DeleteModel : PageModel
    {
        private readonly Broker.Models.ShipContext _context;

        public DeleteModel(Broker.Models.ShipContext context)
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

            Rope = await _context.Ropes.FirstOrDefaultAsync(m => m.RopeID == id);

            if (Rope == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rope = await _context.Ropes.FindAsync(id);

            if (Rope != null)
            {
                _context.Ropes.Remove(Rope);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
