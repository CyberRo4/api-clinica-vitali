using System.ComponentModel.DataAnnotations;

namespace API_Gestión_de_Clínica_Médica_Vitali.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Rol { get; set; } // Admin, Medico, etc
    }
}