using BackEndFormation.Core.Selfies.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Data.TypeConfigurations
{
    internal class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");

            builder.HasKey(item => item.Id);
            builder.HasOne(item => item.Wookie)
                   .WithMany(item => item.Selfies);
        }
        #endregion
    }
}
