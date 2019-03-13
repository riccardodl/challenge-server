using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ropes
{
    public class DetailsModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public DetailsModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
