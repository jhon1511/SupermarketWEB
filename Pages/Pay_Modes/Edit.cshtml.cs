using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Pay_Modes
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;
        public EditModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Pay_Mode PayModes { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var paymode = await _context.Pay_Modes.FirstOrDefaultAsync(m => m.Id == id);
            if (paymode == null)
            {
                return NotFound();
            }
            PayModes = paymode;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Attach(PayModes).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayModeExists(PayModes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }

        private bool PayModeExists(int id)
        {
            return (_context.Pay_Modes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
