namespace HRBackend.AppCore.Models.Entities
{
    public class Demande
    {
        public int IdDemande { get; set; }
        public int IdEmployee { get; set; } // Foreign Key to User
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }
        public string Lieu { get; set; }
        public string  Status { get; set; }
        public User Employe { get; set; }
    }
}
