﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Users
{
    public class RegisterRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
   
    }
}
