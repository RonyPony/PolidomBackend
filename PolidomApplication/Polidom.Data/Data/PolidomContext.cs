using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polidom.Core.Domains;
using Polidom.Data.Configuration;
using Polidom.Data.Data.identity;

namespace Polidom.Data.Data
{
    public class PolidomContext : IdentityDbContext<Account>
    {
        #region Ctor

        /// <summary>
        /// <paramref name="options"/> <see cref="DbContextOptions"/> class.
        /// </summary>
        public PolidomContext( DbContextOptions<PolidomContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    builder.ApplyConfiguration(new RoleConfiguration());
            
        //}

        #endregion

        #region DbSet

        /// <summary>
        /// Get or set context's locations
        /// </summary>
        public DbSet<LocationInfo> Locations { get; set; }

        /// <summary>
        /// Get or set context's reports
        /// </summary>
        public DbSet<Report> Reports { get; set; }

        /// <summary>
        /// Get or set context's report mapping.
        /// </summary>
        public DbSet<AssignReportMapping> ReportMappings { get; set; }


        /// <summary>
        /// Get or set context's photo
        /// </summary>
        public DbSet<Photo> Photos { get; set; }

        #endregion

    }
}
