using Microsoft.EntityFrameworkCore;
using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Data;

namespace API_Gestión_de_Clínica_Médica_Vitali.Services
{
    public class HistorialService
    {
        private readonly AppDbContext _context;

        public HistorialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Historial>> GetAllAsync()
        {
            return await _context.Historiales
                .Include(h => h.Paciente)
                .Include(h => h.Medico)
                .ToListAsync();
        }

        public async Task<Historial?> GetByIdAsync(int id)
        {
            return await _context.Historiales
                .Include(h => h.Paciente)
                .Include(h => h.Medico)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Historial>> GetByPacienteAsync(int idPaciente)
        {
            return await _context.Historiales
                .Include(h => h.Medico)
                .Where(h => h.IdPaciente == idPaciente)
                .OrderByDescending(h => h.FechaConsulta)
                .ToListAsync();
        }

        public async Task<List<Historial>> GetByMedicoAsync(int idMedico)
        {
            return await _context.Historiales
                .Include(h => h.Paciente)
                .Where(h => h.IdMedico == idMedico)
                .OrderByDescending(h => h.FechaConsulta)
                .ToListAsync();
        }

        public async Task<Historial> CreateAsync(Historial historial)
        {
            historial.FechaConsulta = DateTime.Now;
            _context.Historiales.Add(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<Historial?> UpdateAsync(int id, Historial historialActualizado)
        {
            var historial = await _context.Historiales.FindAsync(id);
            if (historial == null) return null;

            historial.IdPaciente = historialActualizado.IdPaciente;
            historial.IdMedico = historialActualizado.IdMedico;
            historial.Diagnostico = historialActualizado.Diagnostico;
            historial.Tratamiento = historialActualizado.Tratamiento;
            historial.FechaConsulta = historialActualizado.FechaConsulta;

            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var historial = await _context.Historiales.FindAsync(id);
            if (historial == null) return false;

            _context.Historiales.Remove(historial);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}