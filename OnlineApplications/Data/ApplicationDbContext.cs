using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineApplications.Models;

namespace OnlineApplications.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Application { get; set; }
        public DbSet<QualificationOnEntry> QualificationOnEntry { get; set; }
        public DbSet<SelectListData> SelectListData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SelectListData>()
                .HasKey(d => new { d.Code });
        }
    }
}
