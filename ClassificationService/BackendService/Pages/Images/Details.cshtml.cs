using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Images
{
    public class DetailsModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public DetailsModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

        public Image Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Image
                .Include(i => i.Rope).FirstOrDefaultAsync(m => m.ImageID == id);

            if (Image == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
