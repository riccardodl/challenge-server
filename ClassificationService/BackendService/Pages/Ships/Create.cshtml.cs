using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackendService.Models;

namespace BackendService.Pages.Ships
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
            return Page();
        }

        [BindProperty]
        public Ship Ship { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newShip = new Ship();
            if (await TryUpdateModelAsync<Ship>(newShip, "Ship", s => s.Name))
            {

                _context.Ship.Add(newShip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}