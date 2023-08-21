using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Services
{
    public class DemandeService : IDemandeService
    {
        private readonly IDemandeRepository _demandeRepository;

        public DemandeService(IDemandeRepository demandeRepository)
        {
            _demandeRepository = demandeRepository;
        }

        public Demande GetDemandeById(int demandeId)
        {
            return _demandeRepository.GetDemandeById(demandeId);
        }

        public IEnumerable<Demande> GetDemandes()
        {
            return _demandeRepository.GetDemandes();
        }

        public void AddDemande(Demande demande)
        {
            _demandeRepository.AddDemande(demande);
        }

        public void UpdateDemande(Demande demande)
        {
            _demandeRepository.UpdateDemande(demande);
        }

        public void DeleteDemande(int demandeId)
        {
            _demandeRepository.DeleteDemande(demandeId);
        }

        public int Count()
        {
            return _demandeRepository.Count();
        }

        public void Save()
        {
            _demandeRepository.Save();
        }
    }

}
