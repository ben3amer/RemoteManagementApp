using AutoMapper;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.DTOs;
using HRBackend.AppCore.Models.Entities;
using HRBackend.AppCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.AppWeb.Controllers
{
    [ApiController]
    [Route("api/demandes"), Authorize]
    public class DemandeController : ControllerBase
    {
        private readonly IDemandeService _demandeService;
        private readonly IMapper _mapper;

        public DemandeController(IDemandeService demandeService, IMapper mapper)
        {
            _mapper = mapper;
            _demandeService = demandeService;
        }

        [HttpGet, Authorize(Roles = "Gestionnaire, Employe")]
        public ActionResult<IEnumerable<Demande>> GetDemandes()
        {
            var demandes = _demandeService.GetDemandes();
            return Ok(demandes);
        }

        [HttpGet("{idDemande}"), Authorize(Roles = "Gestionnaire, Employe")]
        public ActionResult<Demande> GetDemandeById(int idDemande)
        {
            var demande = _demandeService.GetDemandeById(idDemande);
            if (demande == null)
            {
                return NotFound();
            }
            return Ok(demande);
        }

        [HttpPost, Authorize(Roles = "Employe")]
        public ActionResult<Demande> CreateDemande([FromBody] DemandeDTO demandeDto)
        {
            if (demandeDto == null)
            {
                return BadRequest("Contrat data is null.");
            }

            // Map the DTO to the entity
            var demandeEntity = _mapper.Map<Demande>(demandeDto);

            // Add validation and other logic before saving to the database

            // Save the entity to the database
            _demandeService.AddDemande(demandeEntity);
            return Ok(demandeEntity);
        }

        [HttpPut("{idDemande}"), Authorize(Roles = "Gestionnaire, Employe")]
        public ActionResult UpdateContract(int idDemande, DemandeDTO demandeDto)
        {
            if (idDemande != demandeDto.IdDemande)
            {
                return BadRequest();
            }

            if (demandeDto == null)
            {
                return BadRequest("Demande data is null.");
            }

            // Map the DTO to the entity
            var demandeEntity = _mapper.Map<Demande>(demandeDto);

            _demandeService.UpdateDemande(demandeEntity);

            return NoContent();
        }

        [HttpDelete("{idDemande}"), Authorize(Roles = "Gestionnaire, Employe")]
        public ActionResult DeleteContract(int idDemande)
        {
            var contract = _demandeService.GetDemandeById(idDemande);
            if (contract == null)
            {
                return NotFound();
            }

            _demandeService.DeleteDemande(idDemande);

            return NoContent();
        }
    }
}
