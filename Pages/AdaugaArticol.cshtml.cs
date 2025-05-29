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

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine("EROARE MODELSTATE: " + error.ErrorMessage);
                }

                DomeniiSelectList = _context.Domenii
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Nume
                }).ToList();

                return Page();
            }
            _context.Articole.Add(articol);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
