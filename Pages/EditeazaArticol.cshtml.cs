using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages.Shared
{
    public class EditeazaArticolModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Articol Articol { get; set; } = new Articol();
        public EditeazaArticolModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Articol = _context.Articole.FirstOrDefault(s => s.Id == id);

            if (Articol == null)
            {
                return NotFound();
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var articolExistent = _context.Articole.FirstOrDefault(s => s.Id == Articol.Id);

            if (articolExistent == null)
            {
                return NotFound();
            }

            if (articolExistent.EsteProtejat && !User.IsInRole("moderator") && !User.IsInRole("admin") && !User.IsInRole("userInregistrat"))
            {
                return Forbid();
            }

            articolExistent.Titlu = Articol.Titlu;
            articolExistent.Continut = Articol.Continut;
            articolExistent.Autor = Articol.Autor;
            articolExistent.DataPublicare = Articol.DataPublicare;
            articolExistent.Domenii = Articol.Domenii;

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
