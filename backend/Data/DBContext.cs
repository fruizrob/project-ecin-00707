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
            modelBuilder.Entity<backend.Models.patient>().HasData(
                new {
                    Id = 1,
                    years = 19,
                    diagnosis = "cod-19",
                    current_acount = "132343413",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 1,
                    start = 000000
                },
                new {
                    Id = 2,
                    years = 34,
                    diagnosis = "dolor de cabeza",
                    current_acount = "98773672",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 1,
                    start = 000000
                },
                new {
                    Id = 3,
                    years = 29,
                    diagnosis = "paro cardio respiratorio",
                    current_acount = "32565476",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 3,
                    start = 000000
                },
                new {
                    Id = 4,
                    years = 33,
                    diagnosis = "corazon roto :c",
                    current_acount = "43536453",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 6,
                    start = 000000
                },
                new {
                    Id = 5,
                    years = 23,
                    diagnosis = "se pego en el dedo chico del pie",
                    current_acount = "3432355",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 6,
                    start = 000000
                },
                new {
                    Id = 6,
                    years = 73,
                    diagnosis = "torcedura de tobillo",
                    current_acount = "4343532",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 6,
                    start = 000000
                },
                new {
                    Id = 7,
                    years = 19,
                    diagnosis = "quemaduras de gravedad",
                    current_acount = "234-134-1341",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 6,
                    start = 000000
                },
                new {
                    Id = 8,
                    years = 19,
                    diagnosis = "fractura externa sector femur",
                    current_acount = "213-123-2412",
                    destination = "",
                    stretcher = true,
                    type_stretcher = "camilla",
                    more_12h = false,
                    him = "nose que es",
                    ugcc = "menos",
                    sectorId = 6,
                    start = 000000
                }
            );
        }
    }
}