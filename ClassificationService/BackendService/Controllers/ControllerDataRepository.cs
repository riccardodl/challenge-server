using BackendService.Models;
using BackendService.Models.InspectionViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System;

namespace BackendService.Controllers
{
    public class ControllerDataRepository
    {
        private readonly BackendServiceContext _context;

        public static double probability = 75.0;

        public ControllerDataRepository(BackendServiceContext context)
        {
            _context = context;
        }

        public async Task<List<Ship>> GetShipsAsync()
        {
            return await _context.Ship.ToListAsync();
        }

        public async Task<Rope> GetRopeAsync(int shipid, int ropeid)
        {
            return await _context.Rope.Where(r=>r.ShipID == shipid && r.RopeID == ropeid).SingleAsync();
        }


        public async Task<Ship> GetShipAsync(int id)
        {
            return await _context.Ship.FindAsync(id);
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