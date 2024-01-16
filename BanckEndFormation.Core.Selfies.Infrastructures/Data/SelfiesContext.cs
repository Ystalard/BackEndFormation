using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Data.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanckEndFormation.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContext(DbContextOptions options) : DbContext(options)
    {
        #region Constructors
       
        #endregion
        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
        }
        #endregion

        #region Properties
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies{ get; set; }
        #endregion
    }
}
