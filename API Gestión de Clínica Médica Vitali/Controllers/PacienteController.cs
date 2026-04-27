using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API_Gestión_de_Clínica_Médica_Vitali.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // ✅ SOLO UNA RUTA
    [Authorize]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _service.GetByIdAsync(id);

            if (paciente == null)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            var nuevo = await _service.CreateAsync(paciente);

            return Ok(new
            {
                mensaje = "Paciente creado correctamente",
                data = nuevo
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Paciente paciente)
        {
            var actualizado = await _service.UpdateAsync(id, paciente);

            if (actualizado == null)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(new
            {
                mensaje = "Paciente actualizado correctamente",
                data = actualizado
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(new
            {
                mensaje = "Paciente eliminado correctamente"
            });
        }
    }
}
