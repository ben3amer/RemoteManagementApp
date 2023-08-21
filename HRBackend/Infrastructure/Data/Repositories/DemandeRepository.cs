using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Models.Entities;

namespace HRBackend.Infrastructure.Data.Repositories
{
    public class DemandeRepository : IDemandeRepository
    {
        private readonly ApplicationDbContext _context;

        public DemandeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Count ()
        {
            return _context.Demandes.Count();
        }

        public void DeleteDemande (int id)
        {
            var demande = _context.Demandes.FirstOrDefault(x => x.IdDemande == id);
            if (demande != null)
            {
                _context.Demandes.Remove(demande);
                Save();
            }
        }

        public Demande GetDemandeById (int id)
        {
            var demande = _context.Demandes.FirstOrDefault(x => x.IdDemande == id);
            if (demande != null)
            {
                return demande;
            }
            return null;
        }

        public IEnumerable<Demande> GetDemandes ()
        {
            return _context.Demandes.ToList();
        }

        public void AddDemande (Demande demande)
        {
            _context.Demandes.Add(demande);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDemande (Demande demande)
        {
            _context.Demandes.Update(demande);
            Save();
        }
    }
}
