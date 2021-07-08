using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpetual_Guardian_Test.Models
{
    public partial class PGDBContext : DbContext
    {
        public PGDBContext()
        {
        }

        public PGDBContext(DbContextOptions<PGDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UploadFilesDb> UploadFilesDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=091804747-GAGAN\\MSSQLSERVER01;Database=PGDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadFilesDb>(entity =>
            {
                entity.ToTable("UploadFilesDB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
