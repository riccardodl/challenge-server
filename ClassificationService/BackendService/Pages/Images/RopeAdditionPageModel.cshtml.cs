using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Models;
using BackendService.Models.InspectionViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Pages.Images
{
    public class RopeAdditionPageModelModel : PageModel
    {
        List<RopeShipName> datalist;

        public void PopulateRopesDropDownList(BackendServiceContext _context,
            Ship selectedShip)
        {
            var AllShips = _context.Ship;
            var ShipRopes = new HashSet<int>(selectedShip.Ropes.Select(r => r.RopeID));

            datalist = new List<RopeShipName>();
            foreach (var ship in AllShips)
            {
                foreach (var rope in ship.Ropes)
                {
                    datalist.Add(new RopeShipName
                    {
                        ShipName = ship.Name,
                        ShipID = ship.ShipID,
                        RopeID = rope.RopeID

                    });
                }
            }

        }

        public void UpdateRopesDropDownList(BackendServiceContext context, string selectedShip, Rope ropeToUpd, Image img)
        {
            Ship shipToUpd = new Ship();
            if (selectedShip == null)
            {
                ropeToUpd.Images = new List<Image>();
            }
            else
            {
                shipToUpd = context.Ship.Where(s => s.Name == selectedShip).Single();
            }


            var selShipRopes = new HashSet<int>(shipToUpd.Ropes.Select(r => r.RopeID));

            foreach(var rope in context.Rope)
            {
                if (selectedShip == rope.Ship.Name)
                {
                    if (!ropeToUpd.Images.Contains(img))
                        {
                        ropeToUpd.Images.Add(img);
                        //shipToUpd.Ropes.Select(r=> r.RopeID == ropeToUpd.RopeID).Single()
                    }
                }
            }

        }


        public void OnGet()
        {

        }
    }
}