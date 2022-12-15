using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Commands;
using UnikOpstart.Services.KundeProjekter.Application.Queries;

namespace UnikOpstart.Services.KundeProjekter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundeController : Controller
    {
        private readonly ICreateCommand<CreateRequestDtoKunde> _createCommandKunde;
        private readonly IGetQuery<QueryResultDtoKunde> _getQueryKunde;
        private readonly IGetAllQuery<QueryResultDtoKunde> _getAllQueryKunde;
        private readonly IUpdateCommand<UpdateRequestDtoKunde> _updateCommandKunde;
        private readonly IDeleteCommand<KundeEntity> _deleteCommandKunde;

        public KundeController(ICreateCommand<CreateRequestDtoKunde> createCommandKunde,
                               IGetQuery<QueryResultDtoKunde> getQueryKunde,
                               IGetAllQuery<QueryResultDtoKunde> getAllQueryKunde,
                               IUpdateCommand<UpdateRequestDtoKunde> updateCommandKunde,
                               IDeleteCommand<KundeEntity> deleteCommandKunde)
        {
            _createCommandKunde = createCommandKunde;
            _getQueryKunde = getQueryKunde;
            _getAllQueryKunde = getAllQueryKunde;
            _updateCommandKunde = updateCommandKunde;
            _deleteCommandKunde = deleteCommandKunde;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] CreateRequestDtoKunde request)
        {
            try
            {
                _createCommandKunde.Create(request);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Delete(int id)
        {
            try
            {
                _deleteCommandKunde.Delete(id);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QueryResultDtoKunde> Get(int id)
        {
            try
            {
                var result = _getQueryKunde.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QueryResultDtoKunde>> GetAll()
        {
            try
            {
                var result = _getAllQueryKunde.GetAll().ToList();
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
        public void Put([FromBody] UpdateRequestDtoKunde request)
        {
            try
            {
                _updateCommandKunde.Update(request);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }
    }
}