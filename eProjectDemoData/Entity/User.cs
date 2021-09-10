using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoData.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
