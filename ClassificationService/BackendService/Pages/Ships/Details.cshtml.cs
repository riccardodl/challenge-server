﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ships
{
    public class DetailsModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public DetailsModel(BackendService.Models.BackendServiceContext context)
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

            //Ship = await _context.Ship.FirstOrDefaultAsync(m => m.ShipID == id);
            //Consider tracking the entities, so we can modify them
            Ship = await _context.Ship
                                 .Include(s => s.Ropes)
                                 .ThenInclude(r => r.Images)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(m => m.ShipID == id);

            if (Ship == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
