using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gestión_de_Clínica_Médica_Vitali.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _service;

        public CitaController(CitaService service)
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
            var cita = await _service.GetByIdAsync(id);

            if (cita == null)
                return NotFound(new { mensaje = "Cita no encontrada" });

            return Ok(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cita cita)
        {
            var nueva = await _service.CreateAsync(cita);

            return Ok(new
            {
                mensaje = "Cita creada correctamente",
                data = nueva
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cita cita)
        {
            var actualizada = await _service.UpdateAsync(id, cita);

            if (actualizada == null)
                return NotFound(new { mensaje = "Cita no encontrada" });

            return Ok(new
            {
                mensaje = "Cita actualizada correctamente",
                data = actualizada
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Cita no encontrada" });

            return Ok(new
            {
                mensaje = "Cita eliminada correctamente"
            });
        }
    }
}
