using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages.Shared
{
    public class EditeazaArticolModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public Articol Articol { get; set; } = new Articol();

        [BindProperty]
        public IFormFile ImagineNoua { get; set; }

        public EditeazaArticolModel(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            articolExistent.DataPublicare = DateTime.Now;
            articolExistent.Domenii = Articol.Domenii;

            // Verifică dacă s-a selectat o imagine nouă
            if (ImagineNoua != null && ImagineNoua.Length > 0)
            {
                var fileName = Path.GetFileName(ImagineNoua.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "imagine", fileName);

                // Salvează fișierul în wwwroot/imagine
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImagineNoua.CopyTo(stream);
                }

                articolExistent.Imagine = fileName;
            }

            _context.SaveChanges();
            return RedirectToPage("/Index");
        }

    }
}
