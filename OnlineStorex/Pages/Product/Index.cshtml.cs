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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineStorex.Pages.Product
{
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly OnlineStorex.Data.OnlineStorexContext _context;

        public IndexModel(OnlineStorex.Data.OnlineStorexContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList BuyerName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string StoreBuyerName { get; set; }
       
        public async Task OnGetAsync()
        {
            // Store = await _context.Store.ToListAsync();
           
            var store = from m in _context.Store
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                store = store.Where(s => s.ProductName.Contains(SearchString));
            }

            
            Store = await store.ToListAsync();
        }
    }
#pragma warning restore CS8618
#pragma warning restore CS8604
}
