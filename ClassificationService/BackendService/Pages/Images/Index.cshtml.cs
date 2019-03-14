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
        

        public async Task OnGetAsync(int? id, int? rope, int? image)
        {
            Capture = new ImageRopeData();

            Capture.Ships = await _context.Ship 
                .Include(i=>i.Ropes)
                    .ThenInclude(i => i.Images)                
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                ViewData["ShipID"] = id.Value;
                Ship AShip = Capture.Ships
                    .Where(s => s.ShipID == id.Value)
                    .Single();
                Capture.Ropes = AShip.Ropes.ToList();             
            }
            if (rope != null)
            {
                ViewData["RopeID"] = rope.Value;
                Capture.Images = Capture.Ropes.Where(r => r.RopeID == rope.Value)
                    .Single().Images;
            }
            if (image != null)
            {
                ViewData["ImageID"] = image.Value;
                Image AImage = Capture.Images
                    .Where(i => i.ImageID == image.Value)
                    .Single();
                Capture.SpecificImg = AImage;
            }

        }

    }
}
