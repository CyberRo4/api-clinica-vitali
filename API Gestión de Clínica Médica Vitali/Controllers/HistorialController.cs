using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gestión_de_Clínica_Médica_Vitali.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialController : ControllerBase
    {
        private readonly HistorialService _service;

        public HistorialController(HistorialService service)
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
            var historial = await _service.GetByIdAsync(id);

            if (historial == null)
                return NotFound(new { mensaje = "Historial no encontrado" });

            return Ok(historial);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Historial historial)
        {
            var nuevo = await _service.CreateAsync(historial);

            return Ok(new
            {
                mensaje = "Historial creado correctamente",
                data = nuevo
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Historial historial)
        {
            var actualizado = await _service.UpdateAsync(id, historial);

            if (actualizado == null)
                return NotFound(new { mensaje = "Historial no encontrado" });

            return Ok(new
            {
                mensaje = "Historial actualizado correctamente",
                data = actualizado
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Historial no encontrado" });

            return Ok(new
            {
                mensaje = "Historial eliminado correctamente"
            });
        }
    }
}