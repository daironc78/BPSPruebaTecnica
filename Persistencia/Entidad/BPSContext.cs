using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Entidad
{
    public class BPSContext : DbContext
    {
        public BPSContext(DbContextOptions<BPSContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NotaModel>().HasKey(x => new { x.IdEstudiante, x.IdProfesor });
        }

        public DbSet<ProfesorModel> Profesor { get; set; }
        public DbSet<EstudianteModel> Estudiante { get; set; }
        public DbSet<NotaModel> Nota { get; set; }
    }
}
