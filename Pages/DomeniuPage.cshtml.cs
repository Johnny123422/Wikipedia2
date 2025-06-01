using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages
{
    public class DomeniuPageModel : PageModel
    {
        private readonly AppDbContext _context;

        public Articol[] Articole = Array.Empty<Articol>();
        public string DomeniuName { get; set; }

        public DomeniuPageModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Articole = _context.Articole.Include(s => s.Domenii).Where(s => s.DomeniuId == id).ToArray();

            DomeniuName = _context.Domenii.Where(d => d.Id == id).Select(d => d.Nume).FirstOrDefault() ?? "Necunoscut";
        }
    }
}
