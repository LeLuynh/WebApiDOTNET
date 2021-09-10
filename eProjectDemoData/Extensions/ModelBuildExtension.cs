using eProjectDemoData.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoData.Extensions
{
    public static class ModelBuildExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
               new Products() { Id = 1, Name = "Vanz", Description = "suitable for men and women", DateCreated=DateTime.Now },
               new Products() { Id = 2, Name = "Convert", Description = "suitable for men and women", DateCreated = DateTime.Now },
               new Products() { Id = 3, Name = "Nike", Description = "suitable for men and women", DateCreated = DateTime.Now },
               new Products() { Id = 4, Name = "Biti", Description = "suitable for men and women", DateCreated = DateTime.Now }

            );

            var roleId = new Guid ("0D2DE0EA-ABC4-4AF6-B546-2DD26813DEC2");
            var adminId = new Guid("0D2DE0EA-ABC4-4AF6-B546-2DD26813DEC2");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administraction role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin-luynh@gmail.com",
                NormalizedEmail = "admin-luynh@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123@"),
                SecurityStamp = string.Empty,
                FullName = "Le Luynh",
                Dob = new DateTime(2019, 2, 20)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
