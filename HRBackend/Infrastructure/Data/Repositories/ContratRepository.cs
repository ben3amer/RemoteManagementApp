using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Models.Entities;

namespace HRBackend.Infrastructure.Data.Repositories
{
    public class ContratRepository : IContratRepository
    {
        private readonly ApplicationDbContext _context;
        public ContratRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Count ()
        {
            return _context.Contrats.Count();
        }
        public void DeleteContrat (int id)
        {
            var contrat = _context.Contrats.FirstOrDefault(x => x.IdContrat == id);
            if (contrat != null)
            {
                _context.Contrats.Remove(contrat);
                Save();
            }
        }
        public Contrat GetContratById (int id)
        {
            var contrat = _context.Contrats.FirstOrDefault(x => x.IdContrat == id);
            if (contrat != null)
            {
                return contrat;
            }
            return null;
        }
        public IEnumerable<Contrat> GetContrats ()
        {
            return _context.Contrats.ToList();
        }
        public void AddContrat (Contrat contrat)
        {
            _context.Contrats.Add(contrat);
            Save ();
        }
        public void Save ()
        {
            _context.SaveChanges();
        }
        public void UpdateContrat (Contrat contrat)
        {
            _context.Contrats.Update(contrat);
            Save();
        }
    }
}
