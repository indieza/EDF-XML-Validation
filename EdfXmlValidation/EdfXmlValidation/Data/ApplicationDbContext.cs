using EdfXmlValidation.Models.EdfField;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdfXmlValidation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EdfField> EdfFields { get; set; }

        public DbSet<EdfFieldTypeRestriction> EdfFieldTypeRestrictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EdfField>()
                .HasOne(x => x.EdfFieldTypeRestriction)
                .WithMany(x => x.EdfFields)
                .HasForeignKey(x => x.EdfFieldTypeRestrictionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}