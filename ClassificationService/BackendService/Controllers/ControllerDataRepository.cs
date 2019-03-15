using BackendService.Models;
using BackendService.Models.InspectionViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackendService.Controllers
{
    public class ControllerDataRepository
    {
        private readonly BackendServiceContext _context;
        private readonly ILogger _logger;

        public static double probability = 75.0;

        public ControllerDataRepository(BackendServiceContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Ship>> GetShipsAsync()
        {
            return await _context.Ship.ToListAsync();
        }
        public async Task<Ship> GetShipAsync(int id)
        {
            return await _context.Ship.FindAsync(id);
        }
        
        public async Task<Rope> GetRopeAsync(int shipid, int ropeid)
        {
            return await _context.Rope.Where(r=>r.ShipID == shipid && r.RopeID == ropeid).SingleAsync();
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            try
            {
                var elem = await _context.Image.FindAsync(id);
            _context.Image.Remove(elem);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Couldn't apply deletion.");
                return false;
            }
            return true;
        }

        public ImageRopeData Capture { get; set; }

        public KeyValuePair<string,double> MakePrediction(int shipid, int ropeid, int imageid)
        {
            Dictionary<string, double> predictionRes = new Dictionary<string, double>();
            Image Image;

            var Ship = GetShipAsync(shipid);
            if (Ship != null)
            {
                Image = _context.Image.Where(i => i.ImageID == imageid && i.RopeID == ropeid).Single();
                if (Image != null)
                {
                    //List<string> predictionResult = new List<string>();
                    var predictionResult = CV.Program.PredictRawImage(Image.RawImage).ToList();

                    foreach(var res in predictionResult)
                    {
                        var tmp = res.Split(": ");
                        
                        predictionRes.Add(tmp[0].Remove(0,2), Convert.ToDouble(tmp[1].Replace("%","")));
                    }
                }
            }
            predictionRes.OrderByDescending(x => x.Value);
            if (predictionRes.First().Value > probability)
            {
                return predictionRes.First();
            }
            return new KeyValuePair<string, double>();

        }
    }
}