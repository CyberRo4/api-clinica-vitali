using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Gestión_de_Clínica_Médica_Vitali.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(20)]
        public string Cedula { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required, StringLength(10)]
        public string Genero { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [EmailAddress, StringLength(100)]
        public string Correo { get; set; }

        [StringLength(500)]
        public string EstadoClinico { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();

        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; } = new List<Historial>();
    }
}