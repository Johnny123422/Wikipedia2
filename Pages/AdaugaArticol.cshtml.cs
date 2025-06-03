using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<SelectListItem> DomeniiSelectList { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            DomeniiSelectList = _context.Domenii
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Nume
                }).ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile ImagineFisier)
        {
            if (!ModelState.IsValid)
            {
                DomeniiSelectList = _context.Domenii
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Nume
                    }).ToList();

                return Page();
            }

            if (ImagineFisier != null && ImagineFisier.Length > 0)
            {
                var fileName = Path.GetFileName(ImagineFisier.FileName);
                articol.Imagine = fileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagine", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ImagineFisier.CopyToAsync(stream);
                }
            }

            _context.Articole.Add(articol);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


    }
}
