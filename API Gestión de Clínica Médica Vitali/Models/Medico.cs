using System.ComponentModel.DataAnnotations;

namespace API_Gestión_de_Clínica_Médica_Vitali.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string CedulaProfesional { get; set; }

        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string HorarioConsulta { get; set; }
        public string Estado { get; set; }

        // 🔥 CLAVE: Inicializar listas (NO requeridas)
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<Historial> Historiales { get; set; } = new List<Historial>();
    }
}
