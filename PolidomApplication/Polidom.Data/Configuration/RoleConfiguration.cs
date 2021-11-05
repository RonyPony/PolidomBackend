using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polidom.Data.Data.identity;
using System;

namespace Polidom.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
      
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
                ( 
                   new IdentityRole
                   {
                       Id = "1",
                       Name = "ADMIN",
                       NormalizedName = "Admin",
                       ConcurrencyStamp = string.Empty
                   },
                   new IdentityRole
                   {
                       Id = "2",
                       Name = "AUTHORITY",
                       NormalizedName = "Authority",
                       ConcurrencyStamp = string.Empty
                   },
                   new IdentityRole
                   {
                       Id = "3",
                       Name = "COMPLAINANT",
                       NormalizedName = "Complainant",
                       ConcurrencyStamp = string.Empty
                   }
                );
        }
    }
}
