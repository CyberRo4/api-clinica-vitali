using Microsoft.EntityFrameworkCore;
using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Data;

namespace API_Gestión_de_Clínica_Médica_Vitali.Services
{
    public class CitaService
    {
        private readonly AppDbContext _context;

        public CitaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetAllAsync()
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();
        }

        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Cita>> GetByPacienteAsync(int idPaciente)
        {
            return await _context.Citas
                .Include(c => c.Medico)
                .Where(c => c.IdPaciente == idPaciente)
                .ToListAsync();
        }

        public async Task<List<Cita>> GetByMedicoAsync(int idMedico)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Where(c => c.IdMedico == idMedico)
                .ToListAsync();
        }

        public async Task<Cita> CreateAsync(Cita cita)
        {
            cita.Estado = "Pendiente";
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<Cita?> UpdateAsync(int id, Cita citaActualizada)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return null;

            cita.IdPaciente = citaActualizada.IdPaciente;
            cita.IdMedico = citaActualizada.IdMedico;
            cita.Fecha = citaActualizada.Fecha;
            cita.Hora = citaActualizada.Hora;
            cita.Especialidad = citaActualizada.Especialidad;
            cita.Estado = citaActualizada.Estado;

            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<Cita?> CambiarEstadoAsync(int id, string nuevoEstado)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return null;

            cita.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}