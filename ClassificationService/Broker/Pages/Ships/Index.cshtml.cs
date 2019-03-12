using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Broker.Models;

namespace Broker.Pages.Ships
{
    public class IndexModel : PageModel
    {
        private readonly Broker.Models.ShipContext _context;

        public IndexModel(Broker.Models.ShipContext context)
        {
            _context = context;
        }

        public IList<Ship> Ship { get;set; }

        public async Task OnGetAsync()
        {
            Ship = await _context.Ships.ToListAsync();
        }
    }
}
