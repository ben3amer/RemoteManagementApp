﻿using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Interfaces.IRepositories
{
    public interface IDemandeRepository
    {
        IEnumerable<Demande> GetDemandes();
        Demande GetDemandeById(int id);
        void AddDemande(Demande demande);
        void DeleteDemande(int id);
        void UpdateDemande(Demande demande);
        int Count();
        void Save();
    }
}
