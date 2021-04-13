using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTaskManager.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        [NotMapped]
        public string Token { get; set; }
    }
}
