using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Paciente> pacientes { get; set;}
    }
}
