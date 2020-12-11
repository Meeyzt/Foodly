using Foodly.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Foodly.Models.Administration
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<UserIdentity> Members { get; set; }
        public IEnumerable<UserIdentity> NonMembers { get; set; }
    }
}
