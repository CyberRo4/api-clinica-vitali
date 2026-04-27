using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gestión_de_Clínica_Médica_Vitali.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _service;

        public MedicoController(MedicoService service)
        {
            _service = service;
        }

        // GET: api/medico
        [HttpGet]
        public async Task<ActionResult<List<Medico>>> GetAll()
        {
            var medicos = await _service.GetAllAsync();
            return Ok(medicos);
        }

        // GET: api/medico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetById(int id)
        {
            var medico = await _service.GetByIdAsync(id);

            if (medico == null)
            {
                return NotFound(new
                {
                    mensaje = "Médico no encontrado"
                });
            }

            return Ok(medico);
        }

        // GET: api/medico/especialidad/Cardiologia
        [HttpGet("especialidad/{especialidad}")]
        public async Task<ActionResult<List<Medico>>> GetByEspecialidad(string especialidad)
        {
            var medicos = await _service.GetByEspecialidadAsync(especialidad);
            return Ok(medicos);
        }

        // POST: api/medico
        [HttpPost]
        public async Task<ActionResult> Create(Medico medico)
        {
            var nuevo = await _service.CreateAsync(medico);

            return Ok(new
            {
                mensaje = "Médico creado correctamente",
                data = nuevo
            });
        }

        // PUT: api/medico/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Medico medico)
        {
            var actualizado = await _service.UpdateAsync(id, medico);

            if (actualizado == null)
            {
                return NotFound(new
                {
                    mensaje = "Médico no encontrado"
                });
            }

            return Ok(new
            {
                mensaje = "Médico actualizado correctamente",
                data = actualizado
            });
        }

        // DELETE: api/medico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id); // 🔥 CORREGIDO

            if (!eliminado)
            {
                return NotFound(new
                {
                    mensaje = "Médico no encontrado"
                });
            }

            return Ok(new
            {
                mensaje = "Médico eliminado correctamente"
            });
        }
    }
}