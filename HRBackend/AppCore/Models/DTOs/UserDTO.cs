using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Models.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? CIN { get; set; }
        public UserRole? Role { get; set; } 
        public int? IdContrat { get; set; }
        public ICollection<Demande>? Demandes { get; set; }

    }
}
