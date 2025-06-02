using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages
{
    public class ArticolModel : PageModel
    {
        AppDbContext _context;
        public ArticolModel(AppDbContext articolcontext)
        {
            _context = articolcontext;
        }
        public Articol Articol { get; set; }
        public IActionResult OnGet(int articolId)
        {
            Articol = _context.Articole.Include(s => s.Domenii).FirstOrDefault(s => s.Id == articolId);
            if (Articol == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
