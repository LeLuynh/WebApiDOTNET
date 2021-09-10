using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Users
{
    public class LoginRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
