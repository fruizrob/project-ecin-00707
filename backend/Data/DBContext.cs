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
    }
}