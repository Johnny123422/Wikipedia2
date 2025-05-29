using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages
{
    public class AdaugaArticolModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdaugaArticolModel(AppDbContext articolcontext)
        {
            _context = articolcontext;
        }
        [BindProperty]
        public Articol articol { get; set; } = new Articol();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _context.Articole.Add(articol);
            return RedirectToPage("/Home Page");
        }
    }
}
