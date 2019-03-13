using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackendService.Models;

namespace BackendService.Pages.Ropes
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
        ViewData["ShipID"] = new SelectList(_context.Ship, "ShipID", "Name");
            return Page();
        }

        [BindProperty]
        public Rope Rope { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rope.Add(Rope);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}