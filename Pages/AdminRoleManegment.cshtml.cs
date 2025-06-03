using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wikipedia.Models;
using Wikipedia.Data;

namespace Wikipedia.Pages
{
    [Authorize(Roles ="admin")]
    public class AdminRoleManegmentModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleManegmentModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public List<AppUser> Useri { get; set; } = new();

        public async Task OnGetAsync()
        {
            Useri = _userManager.Users.ToList();
        }
        
        public async Task<IActionResult> OnPostAddRolAsync(string userId, string rol)
        {
            var utilizator = await _userManager.FindByIdAsync(userId);
            
            if(utilizator != null && !await _userManager.IsInRoleAsync(utilizator, rol))
            {
                await _userManager.AddToRoleAsync(utilizator, rol);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveRoleAsync(string userId, string rol)
        {
            var utilizator = await _userManager.FindByIdAsync(userId);

            if(utilizator != null && !await _userManager.IsInRoleAsync(utilizator, rol))
            {
                await _userManager.RemoveFromRoleAsync(utilizator, rol);
            }

            return RedirectToPage();
        }
    }
}
