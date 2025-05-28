using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public Articol[] Articole { get; set; } = Array.Empty<Articol>();

        public IndexModel(ILogger<IndexModel> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _context = appDbContext;
        }

        public void OnGet()
        {
            Articole = _context.Articole.Include(s => s.Domenii).ToArray();

        }
    }
}
