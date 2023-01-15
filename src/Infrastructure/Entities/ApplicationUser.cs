using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
    }
}
