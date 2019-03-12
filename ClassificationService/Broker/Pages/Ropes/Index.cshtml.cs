using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Broker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Broker.Pages.Ropes
{
    public class IndexModel : PageModel
    {
        private readonly Broker.Models.RopeContext _context;

        public IndexModel(Broker.Models.RopeContext context)
        {
            _context = context;
        }

        public IList<Rope> Rope { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Tags { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RopeTag { get; set; }

        public async Task OnGetAsync()
        {
            var ropes = from r in _context.Rope select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                ropes = ropes.Where(s => s.Tag.Contains(SearchString));
            }

            Rope = await _context.Rope.ToListAsync();
        }
    }
}
