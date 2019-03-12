using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Broker.Models;

namespace Broker.Pages.Ropes
{
    public class CreateModel : PageModel
    {
        private readonly Broker.Models.RopeContext _context;

        public CreateModel(Broker.Models.RopeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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