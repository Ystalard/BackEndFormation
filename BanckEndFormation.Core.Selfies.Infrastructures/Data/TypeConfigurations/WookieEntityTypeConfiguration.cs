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
    internal class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<Wookie> builder)
        {
            builder.ToTable("Wookie");
        }
        #endregion
    }
}
