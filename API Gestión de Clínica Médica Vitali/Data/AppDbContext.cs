using Microsoft.EntityFrameworkCore;
using API_Gestión_de_Clínica_Médica_Vitali.Models;

namespace API_Gestión_de_Clínica_Médica_Vitali.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Historial> Historiales { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Historial>()
                .HasOne(h => h.Paciente)
                .WithMany(p => p.Historiales)
                .HasForeignKey(h => h.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Historial>()
                .HasOne(h => h.Medico)
                .WithMany(m => m.Historiales)
                .HasForeignKey(h => h.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}