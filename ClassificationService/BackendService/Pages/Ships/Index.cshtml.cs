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
        public string CurrentSort { get; set; }

        public PaginatedList<Ship> Ship { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
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
            int pageSize = 10;
            //Ship = await shipQ.AsNoTracking().ToListAsync();
            Ship = await PaginatedList<Ship>.CreateAsync(shipQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
