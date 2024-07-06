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

        public DbSet<PF_Backend.Models.Recipe> Recipes { get; set; } = default!;
        public DbSet<PF_Backend.Models.Ingredient> Ingredients { get; set; } = default!;
        public DbSet<PF_Backend.Models.Portion> Portions { get; set; } = default!;

    }
}
