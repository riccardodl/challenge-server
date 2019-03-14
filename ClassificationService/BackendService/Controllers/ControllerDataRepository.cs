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

        public async Task<HttpResponseMessage> MakePrediction(int shipid, int ropeid, int imageid)
        {
            HttpResponseMessage predictionResult = new HttpResponseMessage();
            Image Image;

            var Ship = GetShipAsync(shipid);
            if (Ship != null)
            {
                Image = _context.Image.Where(i => i.ImageID == imageid && i.RopeID == ropeid).Single();
                if (Image != null)
                {
                    predictionResult = await CoreCallCustomVisionApi.Program.PredictRawImage(Capture.SpecificImg.RawImage);
                }
            }
            return predictionResult;

        }
    }
}