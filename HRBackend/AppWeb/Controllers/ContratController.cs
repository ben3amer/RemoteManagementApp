using AutoMapper;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.DTOs;
using HRBackend.AppCore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HRBackend.AppWeb.Controllers
{
    [Route("api/contrats")]
    [ApiController]
    public class ContratController : ControllerBase
    {
        private readonly IContratService _contratService;
        private readonly IMapper _mapper;

        public ContratController(IContratService contratService, IMapper mapper)
        {
            _mapper = mapper;
            _contratService = contratService;
        }

        [HttpGet, Authorize(Roles = "Gestionnaire")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Contrat>> GetContrats()
        {
            var contracts = _contratService.GetContrats();
            return Ok(contracts);
        }

        [HttpGet("{contractId}"), Authorize(Roles = "Gestionnaire, Employe")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Contrat> GetContratById(int contratId)
        {
            var contract = _contratService.GetContratById(contratId);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost, Authorize(Roles = "Gestionnaire")]
        public ActionResult<Contrat> CreateContrat(ContratDTO contratDto)
        {

            if (contratDto == null)
            {
                return BadRequest("Contrat data is null.");
            }

            // Map the DTO to the entity
            var contratEntity = _mapper.Map<Contrat>(contratDto);

            // Add validation and other logic before saving to the database

            // Save the entity to the database
            _contratService.AddContrat(contratEntity);

            return Ok(contratEntity);
        }

        [HttpPut("{contractId}"),Authorize(Roles ="Gestionnaire")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateContrat(int contratId,Contrat contrat)
        {
            if (contratId != contrat.IdContrat)
            {
                return BadRequest();
            }

            _contratService.UpdateContrat(contrat);

            return NoContent();
        }

        [HttpDelete("{contractId}"), Authorize(Roles = "Gestionnaire")]
        public ActionResult DeleteContract(int contratId)
        {
            var contract = _contratService.GetContratById(contratId);
            if (contract == null)
            {
                return NotFound();
            }

            _contratService.DeleteContrat(contratId);

            return NoContent();
        }
    }
}
