using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;
using BackendService.Models.InspectionViewModels;

namespace BackendService.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public IndexModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }
                
        public ImageRopeData Capture { get; set; }
        public int ShipID { get; set; }
        public int RopeID { get; set; }
        public int ImageID { get; set; }

        public async Task OnGetAsync(int? ship, int? rope, int? image)
        {
            Capture = new ImageRopeData();

            Capture.Ship = await _context.Ship
                .Include(s => s.ShipID) 
                .Include(s=>s.Name)                
                .OrderBy(s=>s.Name)
                .AsNoTracking()
                .ToListAsync();

            if (ShipID != null)
            {
                ShipID = ship.Value;
            }
        }
    }
}
