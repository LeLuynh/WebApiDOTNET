using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eProjectDemoData.EF
{
    public  class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ProjectDemoContext>
    {
        public ProjectDemoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDemoContext>();
            optionsBuilder.UseSqlServer(connectString);

            return new ProjectDemoContext(optionsBuilder.Options);
        }
    }
}
