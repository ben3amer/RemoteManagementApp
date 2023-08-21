namespace HRBackend.AppCore.Models.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public byte[]? HashedPassword { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public int? CIN { get; set; }
        public UserRole? Role { get; set; }
        public int? IdContrat { get; set; }
        public Contrat? Contrat { get; set; }
        public ICollection<Demande>? Demandes { get; set; }
        public User() 
        { 
        }
    }

    public enum UserRole
    {
        Gestionnaire, // Admin
        Employe // simple user : employe
    }
}