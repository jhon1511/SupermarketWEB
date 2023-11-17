using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Pay_Modes
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;
        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pay_Mode PayMode { get; set; } = default!;

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pay_Modes == null || PayMode == null)
            {
                return Page();
            }
            _context.Pay_Modes.Add(PayMode);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
