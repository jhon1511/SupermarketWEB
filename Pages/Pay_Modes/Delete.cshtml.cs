using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Pay_Modes
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pay_Mode PayMode { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pay_Modes == null)
            {
                return NotFound();
            }
            var paymode = await _context.Pay_Modes.FirstOrDefaultAsync(c => c.Id == id);
            if (paymode == null)
            {
                return NotFound();
            }
            else
            {
                PayMode = paymode;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pay_Modes == null)
            {
                return NotFound();
            }
            var paymode = await _context.Pay_Modes.FindAsync(id);
            if (paymode != null)
            {
                PayMode = paymode;
                _context.Pay_Modes.Remove(paymode);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
