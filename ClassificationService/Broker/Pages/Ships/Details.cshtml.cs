using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Broker.Models;

namespace Broker.Pages.Ships
{
    public class DetailsModel : PageModel
    {
        private readonly Broker.Models.ShipContext _context;

        public DetailsModel(Broker.Models.ShipContext context)
        {
            _context = context;
        }

        public Ship Ship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ship = await _context.Ships.FirstOrDefaultAsync(m => m.ShipID == id);

            if (Ship == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
