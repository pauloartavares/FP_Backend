using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF_Backend.Models;

namespace PF_Backend.Data
{
    public class PF_BackendContext : DbContext
    {
        public PF_BackendContext (DbContextOptions<PF_BackendContext> options)
            : base(options)
        {
        }

        public DbSet<PF_Backend.Models.Recipes> Recipes { get; set; } = default!;
        public DbSet<PF_Backend.Models.Ingredients> Ingredients { get; set; } = default!;
        public DbSet<PF_Backend.Models.Portions> Portions { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredients>()
           .HasMany(e => e.Recipes)
           .WithMany(e => e.Ingredients)
           .UsingEntity<Portions>(
               l => l.HasOne<Recipes>().WithMany().HasForeignKey(e => e.IdRecipes),
               r => r.HasOne<Ingredients>().WithMany().HasForeignKey(e => e.IdIngredients));

            modelBuilder.Entity<Recipes>()
           .HasMany(e => e.Ingredients)
           .WithMany(e => e.Recipes)
           .UsingEntity<Portions>(
               l => l.HasOne<Ingredients>().WithMany().HasForeignKey(e => e.IdIngredients),
               r => r.HasOne<Recipes>().WithMany().HasForeignKey(e => e.IdRecipes));
        }
    }
}
