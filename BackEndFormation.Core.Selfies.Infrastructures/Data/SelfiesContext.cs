using BackEndFormation.Core.FrameWork;
using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Data.TypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContext(DbContextOptions options) : IdentityDbContext(options), IUnitOfWork
    {
        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PicturesEntityTypeConfiguration());
        }
        #endregion

        #region Properties
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies{ get; set; }

        public DbSet<Picture> Pictures { get; set; }
        #endregion
    }
}
