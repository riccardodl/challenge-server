using BackendService.Models;
using BackendService.Models.InspectionViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCallCustomVisionApi;
using System.Linq;
using System.Net.Http;

namespace BackendService.Controllers
{
    public class ControllerDataRepository
    {
        private readonly BackendServiceContext _context;

        public ControllerDataRepository(BackendServiceContext context)
        {
            _context = context;

        }


        public async Task<List<Ship>> GetShipsAsync()
        {
            return await _context.Ship.ToListAsync();
        }


        public async Task<Ship> GetShipAsync(int id)
        {
            return await _context.Ship.FindAsync(id);
        }

        public ImageRopeData Capture { get; set; }

        public async Task<HttpResponseMessage> MakePrediction(int? shipid, int? ropeid, int? imageid)
        {
            HttpResponseMessage predictionResult = new HttpResponseMessage();
            Capture = new ImageRopeData();

            Capture.Ships = _context.Ship
                .Include(i => i.Ropes)
                    .ThenInclude(i => i.Images)
                .AsNoTracking()
                .ToList();

            if (shipid != null)
            {                
                Ship AShip = Capture.Ships
                    .Where(s => s.ShipID == shipid.Value)
                    .Single();
                Capture.Ropes = AShip.Ropes.ToList();
            }
            if (ropeid != null)
            {                
                Capture.Images = Capture.Ropes
                    .Where(r => r.RopeID == ropeid.Value).Single().Images;
            }
            if (imageid != null)
            {                
                Capture.SpecificImg = Capture.Images
                    .Where(i => i.ImageID == imageid.Value)
                    .Single();
            }

            if (Capture.SpecificImg.RawImage != null)
            {
                predictionResult = await CoreCallCustomVisionApi.Program.PredictRawimage(Capture.SpecificImg.RawImage);
                
            }
            return predictionResult;

        }
    }
}