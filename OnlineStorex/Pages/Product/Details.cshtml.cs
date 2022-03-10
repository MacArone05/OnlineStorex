#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineStorex.Data;
using OnlineStorex.Pages;

namespace OnlineStorex.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly OnlineStorex.Data.OnlineStorexContext _context;

        public DetailsModel(OnlineStorex.Data.OnlineStorexContext context)
        {
            _context = context;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Store.FirstOrDefaultAsync(m => m.ID == id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
