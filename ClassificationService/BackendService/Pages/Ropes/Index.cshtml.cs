using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackendService.Models;

namespace BackendService.Pages.Ropes
{
    public class IndexModel : PageModel
    {
        private readonly BackendService.Models.BackendServiceContext _context;

        public IndexModel(BackendService.Models.BackendServiceContext context)
        {
            _context = context;
        }

        public IList<Rope> Rope { get;set; }

        public async Task OnGetAsync()
        {
            Rope = await _context.Rope
                .Include(r => r.Images)
                .Include(r=>r.Ship)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
