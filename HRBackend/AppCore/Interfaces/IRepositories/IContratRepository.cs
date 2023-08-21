using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Interfaces.IRepositories
{
    public interface IContratRepository
    {
        IEnumerable<Contrat> GetContrats();
        Contrat GetContratById(int id);
        void AddContrat(Contrat contrat);
        void UpdateContrat(Contrat contrat);
        void DeleteContrat(int id);
        int Count();
        void Save();
    }
}
