using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetancer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedarbejderController : Controller
    {
        private readonly ICreateCommand<CreateRequestDtoMedarbejder> _createCommandMedarbejder;
        private readonly IGetQuery<QueryResultDtoMedarbejder> _getQueryMedarbejder;
        private readonly IGetAllQuery<QueryResultDtoMedarbejder> _getAllQueryMedarbejder;
        private readonly IUpdateCommand<UpdateRequestDtoMedarbejder> _updateCommandMedarbejder;
        private readonly IDeleteCommand<MedarbejderEntity> _deleteCommandMedarbejder;
        private readonly IGetAllByKompetenceIdQueryMedarbejder _getAllByKompetenceIdQueryMedarbejder;
        

        public MedarbejderController(ICreateCommand<CreateRequestDtoMedarbejder> createCommandMedarbejder,
                                     IGetQuery<QueryResultDtoMedarbejder> getQueryMedarbejder,
                                     IGetAllQuery<QueryResultDtoMedarbejder> getAllQueryMedarbejder,
                                     IUpdateCommand<UpdateRequestDtoMedarbejder> updateCommandMedarbejder,
                                     IDeleteCommand<MedarbejderEntity> deleteCommandMedarbejder,
                                     IGetAllByKompetenceIdQueryMedarbejder getAllByKompetenceIdQueryMedarbejder)
        {
            _createCommandMedarbejder = createCommandMedarbejder;
            _getQueryMedarbejder = getQueryMedarbejder;
            _getAllQueryMedarbejder = getAllQueryMedarbejder;
            _updateCommandMedarbejder = updateCommandMedarbejder;
            _deleteCommandMedarbejder = deleteCommandMedarbejder;
            _getAllByKompetenceIdQueryMedarbejder = getAllByKompetenceIdQueryMedarbejder;
        }

        // POST api/<UserController>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CreateRequestDtoMedarbejder createRequestDto)
        {
            try
            {
                _createCommandMedarbejder.Create(createRequestDto);
                return Ok();   
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UserController>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QueryResultDtoMedarbejder> Get(int id)
        {
            try
            {
                var result = _getQueryMedarbejder.Get(id);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GETALL api/<UserController>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoMedarbejder>> GetAll()
        {
            try
            {
                var result = _getAllQueryMedarbejder.GetAll().ToList();
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GETALL api/<UserController>
        [HttpGet("GetAllMedarbejderByKompetenceId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoMedarbejder>> GetAll(int id)
        {
            try
            {
                // Hvis id er 0, så returner alle medarbejdere, da id = 0 betyder at ingen kompetence er nødvendig til opgaven.
                if(id == 0)
                {
                    return Ok(_getAllQueryMedarbejder.GetAll().ToList());
                }

                var medarbejdere = _getAllByKompetenceIdQueryMedarbejder.GetAllByKompetenceId(id).ToList();

                var result = new List<QueryResultDtoMedarbejder>();

                foreach (var m in medarbejdere)
                {
                    result.Add(_getQueryMedarbejder.Get(m.MedarbejderId));
                }
                
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // UPDATE api/<UserController>
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(UpdateRequestDtoMedarbejder requestDto)
        {
            try
            {
                _updateCommandMedarbejder.Update(requestDto);
                return Ok();
            }
            catch (System.Exception e)
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
                _deleteCommandMedarbejder.Delete(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}