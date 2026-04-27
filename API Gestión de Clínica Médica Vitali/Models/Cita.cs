using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Gestión_de_Clínica_Médica_Vitali.Models
{
    public class Cita
    {
       
        [Key]
        public int Id { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        [JsonIgnore]
        public Paciente? Paciente { get; set; }

        [JsonIgnore]
        public Medico? Medico { get; set; }


        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
      

        public DateTime Fecha { get; set; }

        public string Hora { get; set; }

        public string Especialidad { get; set; }

        public string Estado { get; set; }
    }
}
