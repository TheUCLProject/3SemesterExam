using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Commands;
using UnikOpstart.Services.KundeProjekter.Application.Queries;

namespace UnikOpstart.Services.KundeProjekter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektController : Controller
    {
        private readonly ICreateCommand<CreateRequestDtoProjekt> _createProjecktCommand;
        private readonly IGetQuery<QueryResultDtoProjekt> _getQueryProjekt;
        private readonly IGetAllQuery<QueryResultDtoProjekt> _getAllQueryProjekt;
        private readonly IGetAllProjekterByKundeId _getAllProjekterByKundeId;
        private readonly IUpdateCommand<UpdateRequestDtoProjekt> _updateProjektCommand;
        private readonly IDeleteCommand<ProjektEntity> _deleteProjektCommand;

        public ProjektController(ICreateCommand<CreateRequestDtoProjekt> createProjektCommand,
            IGetQuery<QueryResultDtoProjekt> getQueryProjekt,
            IGetAllQuery<QueryResultDtoProjekt> getAllQueryProjekt,
            IGetAllProjekterByKundeId getAllProjekterByKundeId,
            IUpdateCommand<UpdateRequestDtoProjekt> updateProjektCommand,
            IDeleteCommand<ProjektEntity> deleteProjektCommand)
        {
            _createProjecktCommand = createProjektCommand;
            _getQueryProjekt = getQueryProjekt;
            _getAllQueryProjekt = getAllQueryProjekt;
            _getAllProjekterByKundeId = getAllProjekterByKundeId;
            _updateProjektCommand = updateProjektCommand;
            _deleteProjektCommand = deleteProjektCommand;
        }

        // POST api/<UserController>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(CreateRequestDtoProjekt requestDto)
        {
            try
            {
                _createProjecktCommand.Create(requestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoProjekt>> GetAll()
        {
            try
            {
                var result = _getAllQueryProjekt.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("GetAllProjekterByKundeId/{kundeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoProjekt>> GetAllProjekterByKundeId(int kundeId)
        {
            try
            {
                var result = _getAllProjekterByKundeId.GetAllProjekterByKundeId(kundeId).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<UserController>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QueryResultDtoProjekt> Get(int id)
        {
            try
            {
                var result = _getQueryProjekt.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] UpdateRequestDtoProjekt requestDto)
        {
            try
            {
                _updateProjektCommand.Update(requestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<UserController>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Delete(int id)
        {
            try
            {
                _deleteProjektCommand.Delete(id);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }
    }
}