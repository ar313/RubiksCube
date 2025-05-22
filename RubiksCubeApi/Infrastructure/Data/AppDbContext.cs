using Microsoft.EntityFrameworkCore;
using RubiksCubeApi.Domain.Entities;
using System.Collections.Generic;

namespace RubiksCubeApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<RubiksCube> RubiksCubes { get; set; }
        public DbSet<RubiksBox> RubiksBoxes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RubiksCube>()
                .HasMany(c => c.RubiksBoxes)
                .WithOne(s => s.RubiksCube)
                .HasForeignKey(s => s.RubiksCubeId);
        }
    }
}
