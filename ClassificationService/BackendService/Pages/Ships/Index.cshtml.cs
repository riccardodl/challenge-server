using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ships
{
    public class IndexModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public IndexModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }        
        public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        public IList<Ship> Ship { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Ship> shipQ = from s 
                                         in _context.Ship
                                         select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                shipQ = shipQ.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    shipQ = shipQ.OrderByDescending(s => s.Name);
                    break;
                default:
                    shipQ = shipQ.OrderBy(s => s.Name);
                    break;
            }

            Ship = await shipQ.AsNoTracking().ToListAsync();
        }
    }
}
