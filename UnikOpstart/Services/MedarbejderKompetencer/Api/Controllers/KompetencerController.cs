using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompetencerController : Controller
    {
        private readonly ICreateCommand<CreateRequestDtoKompetence> _createCommand;
        private readonly IUpdateCommand<UpdateRequestDtoKompetence> _updateCommand;
        private readonly IDeleteCommand<MedarbejderKompEntity> _deleteCommand;
        private readonly IGetQuery<QueryResultDtoKompetence> _getQuery;
        private readonly IGetAllQuery<QueryResultDtoKompetence> _getAllQuery;
        private readonly IGetByEgenskabQueryKompetence _getByEgenskabQuery;
        private readonly ICreateCommand<CreateRequestDtoMedarbejderKomp> _createCommandMedarbejderKompetencer;
        private readonly IGetAllByMedarbejderIdQueryKompetence _getAllByMedarbejderIdQuery;
        public KompetencerController(ICreateCommand<CreateRequestDtoKompetence> createCommand,
                                    IUpdateCommand<UpdateRequestDtoKompetence> updateCommand,
                                    IDeleteCommand<MedarbejderKompEntity> deleteCommand,
                                    IGetQuery<QueryResultDtoKompetence> getQuery,
                                    IGetAllQuery<QueryResultDtoKompetence> getAllQuery,
                                    ICreateCommand<CreateRequestDtoMedarbejderKomp> createCommandMedarbejderKompetencer,
                                    IGetAllByMedarbejderIdQueryKompetence getAllByMedarbejderIdQuery,
                                    IGetByEgenskabQueryKompetence getByEgenskabQuery)
        {
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _getQuery = getQuery;
            _getAllQuery = getAllQuery;
            _createCommandMedarbejderKompetencer = createCommandMedarbejderKompetencer;
            _getAllByMedarbejderIdQuery = getAllByMedarbejderIdQuery;
            _getByEgenskabQuery = getByEgenskabQuery;
        }

        // POST api/<UserController>
        [HttpPost("CreateAndAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CreateRequestDtoKompetence createRequestDto)
        {
            try
            {
                _createCommand.Create(createRequestDto);

                var createdEntity = _getByEgenskabQuery.GetByEgenskab(createRequestDto.Egenskab);

                var requestDto = new CreateRequestDtoMedarbejderKomp
                {
                    MedarbejderId = createRequestDto.MedarbejderId,
                    KompetenceId = createdEntity.Id
                };

                _createCommandMedarbejderKompetencer.Create(requestDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CreateRequestDtoMedarbejderKomp requestDto)
        {
            try
            {
                _createCommandMedarbejderKompetencer.Create(requestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UserController>
        [HttpGet("({id})")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QueryResultDtoKompetence> Get(int id)
        {
            try
            {
                var result = _getQuery.Get(id);
                return result;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<UserController>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoKompetence>> GetAll()
        {
            try
            {
                var result = _getAllQuery.GetAll().ToList();
                return result;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<UserController>
        [HttpGet("GetAllByMedarbejderId/{medarbejderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoKompetence>> GetAllByMedarbejderId(int medarbejderId)
        {
            try
            {
                var kompetencer = _getAllByMedarbejderIdQuery.GetAllByMedarbejderId(medarbejderId).ToList();
                
                var result = new List<QueryResultDtoKompetence>();
                
                foreach (var komp in kompetencer)
                {
                    var kompetence = _getQuery.Get(komp.KompetenceId);
                    result.Add(kompetence);
                }

                return result;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/<UserController>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] UpdateRequestDtoKompetence updateRequestDto)
        {
            try
            {
                _updateCommand.Update(updateRequestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<UserController>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}