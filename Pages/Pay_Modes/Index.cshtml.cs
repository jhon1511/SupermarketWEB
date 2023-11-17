using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Pay_Modes
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }
        public IList<Pay_Mode> Pay_Modes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Pay_Modes = await _context.Pay_Modes.ToListAsync();
            }
        }
    }
}