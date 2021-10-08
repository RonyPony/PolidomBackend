using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Data.Data.identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polidom.Data.Data
{
    public class PolidomContext : IdentityDbContext<Account>
    {
        public PolidomContext( DbContextOptions<PolidomContext> options) : base(options)
        {
        }

        public DbSet<LocationInfo> Locations { get; set; }
        public DbSet<Report> Reports { get; set; }
    
    }
}
