using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ships
{
    public class EditModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public EditModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ship Ship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ship = await _context.Ship.FirstOrDefaultAsync(m => m.ShipID == id);

            if (Ship == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //FindAsync makes the DB callonly if the entity in the context has changed
            Ship = await _context.Ship.FindAsync(id);

            if (await TryUpdateModelAsync<Ship>(
                Ship,
                "Ship",
                s => s.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }




            _context.Attach(Ship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipExists(Ship.ShipID))
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

        private bool ShipExists(int id)
        {
            return _context.Ship.Any(e => e.ShipID == id);
        }
    }
}
