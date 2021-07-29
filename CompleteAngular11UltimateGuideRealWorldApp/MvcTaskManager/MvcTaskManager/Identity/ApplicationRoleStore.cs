using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MvcTaskManager.Models;

namespace MvcTaskManager.Identity
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext>
    {
        public ApplicationRoleStore(ApplicationDbContext applicationDbContext, IdentityErrorDescriber identityErrorDescriber)
            :base(applicationDbContext, identityErrorDescriber)
        {

        }
    }
}
