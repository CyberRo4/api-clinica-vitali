using Microsoft.EntityFrameworkCore;
using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Data;

namespace API_Gestión_de_Clínica_Médica_Vitali.Services
{
    public class MedicoService
    {
        private readonly AppDbContext _context;

        public MedicoService(AppDbContext context)
        {
            _context = context;
        }

        // 🔵 GET ALL
        public async Task<List<Medico>> GetAllAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        // 🔵 GET BY ID
        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        // 🔵 GET POR ESPECIALIDAD
        public async Task<List<Medico>> GetByEspecialidadAsync(string especialidad)
        {
            return await _context.Medicos
                .Where(m => m.Especialidad == especialidad && m.Estado == "Activo")
                .ToListAsync();
        }

        // 🟢 CREATE
        public async Task<Medico> CreateAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        // 🟡 UPDATE
        public async Task<Medico?> UpdateAsync(int id, Medico medicoActualizado)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) return null;

            medico.Nombre = medicoActualizado.Nombre;
            medico.CedulaProfesional = medicoActualizado.CedulaProfesional;
            medico.Especialidad = medicoActualizado.Especialidad;
            medico.Telefono = medicoActualizado.Telefono;
            medico.Correo = medicoActualizado.Correo;
            medico.HorarioConsulta = medicoActualizado.HorarioConsulta;
            medico.Estado = medicoActualizado.Estado;

            await _context.SaveChangesAsync();
            return medico;
        }

        // 🔴 DELETE (CORREGIDO PRO)
        public async Task<bool> DeleteAsync(int id)
        {
            var medico = await _context.Medicos
                .Include(m => m.Citas)
                .Include(m => m.Historiales)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null)
                return false;

            // 🔥 eliminar relaciones primero
            _context.Citas.RemoveRange(medico.Citas);
            _context.Historiales.RemoveRange(medico.Historiales);

            // 🔥 eliminar medico
            _context.Medicos.Remove(medico);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
