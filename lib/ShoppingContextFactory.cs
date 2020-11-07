using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShoppingLibrary
{
    public class ShoppingContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DatabaseContext CreateDbContext(string[] args)
        {
            String baseDir = Path.Combine(Directory.GetCurrentDirectory(), @"..\web");

            var configuration = new ConfigurationBuilder()
               .SetBasePath(baseDir)
               .AddJsonFile("appsettings.json", optional: false)
               .Build();

            var settingsSection = configuration.GetSection("Settings");

            var conStr = settingsSection.GetValue<string>("DatabaseName");

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(baseDir, conStr));
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseLazyLoadingProxies();

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
