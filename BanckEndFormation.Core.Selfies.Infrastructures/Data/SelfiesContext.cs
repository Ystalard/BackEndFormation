using BackEndFormation.Core.Selfies.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanckEndFormation.Core.Selfies.Infrastructures.Data
{
    internal class SelfiesContext : DbContext
    {
        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Properties
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies{ get; set; }
        #endregion
    }
}
