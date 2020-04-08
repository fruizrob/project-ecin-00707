using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DBContext : DbContext {
        public DBContext (DbContextOptions<DBContext> options) : base(options) {}
        public DbSet<temp_categorization> temp_categorizations { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<patient> patients { get; set; }
        public DbSet<mov_history> mov_histories { get; set; }
        public DbSet<report> reports { get; set; }
        public DbSet<sector> sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<backend.Models.sector>().HasData(
                new { 
                    Id = 1, 
                    title = "Sector C1",
                    description = "Emergencia Vital",
                    color = "rgba(128, 0, 0)",
                    num_bed = 5
                    },
                new {
                    Id = 2,
                    title = "Sector C2",
                    description = "Urgencia / Alta Complejidad",
                    color = "rgba(255, 0, 0)",
                    num_bed = 5
                },
                new {
                    Id = 3,
                    title = "Sector C3",
                    description = "Condicion de Mediana Complejidad",
                    color = "rgb(255, 102, 0)",
                    num_bed = 5
                },
                new {
                    Id = 4,
                    title = "Sector C4",
                    description = "No Urgente / Baja complejidad",
                    color = "rgb(255, 153, 0)",
                    num_bed = 5
                },
                new {
                    Id = 5,
                    title = "Sector C5",
                    description = "No Urgente / Atencion General",
                    num_bed = 5
                },
                new {
                    Id = 6,
                    title = "Categorización",
                    description = "Paciente en espera",
                    color = "#0f69b4",
                    num_bed = 0
                });
        }
    }
}