using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackendService.Models;

namespace BackendService.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public CreateModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RopeID"] = new SelectList(_context.Rope, "RopeID", "RopeID");
            return Page();
        }

        [BindProperty]
        public Image Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Image.Add(Image);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}