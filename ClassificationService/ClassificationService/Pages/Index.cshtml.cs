using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassificationService.Models;

namespace ClassificationService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ClassificationService.Models.ClassificationServiceContext _context;

        public IndexModel(ClassificationService.Models.ClassificationServiceContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; }

        public async Task OnGetAsync()
        {
            Image = await _context.Image.ToListAsync();
        }
    }
}
