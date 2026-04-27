using Microsoft.EntityFrameworkCore;
using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Data;

namespace API_Gestión_de_Clínica_Médica_Vitali.Services
{
    public class PacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente?> GetByCedulaAsync(string cedula)
        {
            return await _context.Pacientes
                .FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            paciente.FechaRegistro = DateTime.Now;
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente?> UpdateAsync(int id, Paciente pacienteActualizado)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return null;

            paciente.Nombre = pacienteActualizado.Nombre;
            paciente.Cedula = pacienteActualizado.Cedula;
            paciente.FechaNacimiento = pacienteActualizado.FechaNacimiento;
            paciente.Genero = pacienteActualizado.Genero;
            paciente.Direccion = pacienteActualizado.Direccion;
            paciente.Telefono = pacienteActualizado.Telefono;
            paciente.Correo = pacienteActualizado.Correo;
            paciente.EstadoClinico = pacienteActualizado.EstadoClinico;

            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

