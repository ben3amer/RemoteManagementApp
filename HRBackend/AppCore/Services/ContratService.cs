using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.Entities;


namespace HRBackend.AppCore.Services
{
    public class ContratService : IContratService
    {
        private readonly IContratRepository _contratRepository;

        public ContratService(IContratRepository contractRepository)
        {
            _contratRepository = contractRepository;
        }

        public Contrat GetContratById(int contractId)
        {
            return _contratRepository.GetContratById(contractId);
        }

        public IEnumerable<Contrat> GetContrats()
        {
            return _contratRepository.GetContrats();
        }

        public void AddContrat(Contrat contract)
        {
            _contratRepository.AddContrat(contract);
        }

        public void UpdateContrat(Contrat contrat)
        {
            _contratRepository.UpdateContrat(contrat);
        }

        public void DeleteContrat(int contratId)
        {
            _contratRepository.DeleteContrat(contratId);
        }

        public int Count ()
        {
            return (_contratRepository.Count());
        }

        public void Save()
        {
            _contratRepository.Save();
        }
    }

}
