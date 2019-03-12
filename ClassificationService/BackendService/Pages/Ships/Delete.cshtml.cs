using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;
using Microsoft.Extensions.Logging;

namespace BackendService.Pages.Ships
{
    public class DeleteModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;
        private readonly ILogger _logger;
        private object services;

        public DeleteModel(BackendService.Models.BackendServiceContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Ship Ship { get; set; }
        public string Error { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? UnsavedChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ship = await _context.Ship.AsNoTracking().FirstOrDefaultAsync(m => m.ShipID == id);

            if (UnsavedChangesError.GetValueOrDefault())
            {
                Error = "The entry has not been deleted. Try again.";
            }
            if (Ship == null)
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

            var toDel = await _context.Ship.AsNoTracking().FirstOrDefaultAsync(s=> s.ShipID == id);
            if (toDel == null)
            {
                return NotFound();
            }
            try
            {
                _context.Ship.Remove(toDel);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Couldn't apply deletion.");
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
            
        }
    }
}
