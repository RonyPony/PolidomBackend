using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polidom.Data.Data
{
    public class PolidomContext : DbContext
    {
        public PolidomContext( DbContextOptions<PolidomContext> options) : base(options)
        {
        }

        public DbSet<LocationInfo> Locations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
    
    }
}
