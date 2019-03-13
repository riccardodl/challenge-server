using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Models;
using BackendService.Models.InspectionViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Pages.Ships
{
    public class AboutModel : PageModel
    {
        private readonly BackendServiceContext _context;

        public AboutModel(BackendServiceContext context)
        {
            _context = context;
        }

        public IList<InspectionGroup> Inspection { get; set; }        

        public async Task OnGetAsync()
        {
            IQueryable<InspectionGroup> data =
                from ropes in _context.Rope
                group ropes by ropes.ShipID
                into shipGroup
                select new InspectionGroup()
                {
                    ShipName = _context.Ship
                                       .Where(s => s.ShipID == shipGroup.Key)
                                       .Select(x => x.Name)
                                       .SingleOrDefault()
                                       .ToString(),                    
                    RopesCount = shipGroup.Count(),

                    /*Tags = from elem in shipGroup
                           group elem by elem.Tag
                           into sameTags
                           select new Tuple<Tag,int>(sameTags.){ }*/
                    Tags = shipGroup.GroupBy(c=> c.Tag)
                    .Select(t=>new Tuple<Tag, int>(t.First().Tag, t.Count())).ToList()
                };

            Inspection = await data.AsNoTracking().ToListAsync();
        }
    }
}