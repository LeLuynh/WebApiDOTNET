using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
    }
}
