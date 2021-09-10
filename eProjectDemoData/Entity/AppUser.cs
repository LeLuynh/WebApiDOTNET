using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoData.Entity
{
    public class AppUser: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
    }
}
