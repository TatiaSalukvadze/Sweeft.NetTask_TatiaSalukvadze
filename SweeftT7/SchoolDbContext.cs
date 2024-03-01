using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftT7
{
    internal class SchoolDbContext : DbContext
    {

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public SchoolDbContext() { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<TeacherPupil> TeacherPupils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string
            optionsBuilder.UseSqlServer("server=WINDOWS-GSRIK6L\\SQLEXPRESS;database=schoolT7;trusted_connection=true;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeacherPupil>().HasKey(sc => new { sc.TId, sc.PId });
            // Define relationships
            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Teacher)
                .WithMany()
                .HasForeignKey(tp => tp.TId);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Pupil)
                .WithMany()
                .HasForeignKey(tp => tp.PId);

        }




    }
}
