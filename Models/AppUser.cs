using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Wikipedia.Models
{
    public class AppUser : IdentityUser
    {
        public string Nume { get; set; } = "";
        public string Prenume { get; set; } = "";

        public string Email { get; set; } = "";

    }
}
