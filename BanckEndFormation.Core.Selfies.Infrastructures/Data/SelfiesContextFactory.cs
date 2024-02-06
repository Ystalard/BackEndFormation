using BanckEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
    {
        public SelfiesContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Data", "settings", "appsettings.json"));
            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            DbContextOptionsBuilder dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDatabase"), b => b.MigrationsAssembly("BackEndFormation.Core.Selfies.Data.Migration"));

            SelfiesContext context = new(dbContextOptionsBuilder.Options);

            return context;
        }
    }
}
