using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTaskManager.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        [NotMapped] // We do not want to store the token in the database
        public string Token { get; set; }
    }
}
