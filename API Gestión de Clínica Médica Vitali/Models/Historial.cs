using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gestión_de_Clínica_Médica_Vitali.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }

        public Paciente? Paciente { get; set; }

        [Required]
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }

        public Medico? Medico { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(500)]
        public string Tratamiento { get; set; }

        [Required]
        public DateTime FechaConsulta { get; set; }
    }
}
