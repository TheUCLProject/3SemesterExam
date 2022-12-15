using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Commands;
using UnikOpstart.Services.KundeProjekter.Application.Queries;

namespace UnikOpstart.Services.KundeProjekter.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OpgaveController : Controller
{
    private readonly ICreateCommand<CreateRequestDtoOpgave> _createCommandOpgave;
    private readonly IGetQuery<QueryResultDtoOpgave> _getQueryOpgave;
    private readonly IGetAllQuery<QueryResultDtoOpgave> _getAllQueryOpgave;
    private readonly IUpdateCommand<UpdateRequestDtoOpgave> _updateCommandOpgave;
    private readonly IDeleteCommand<OpgaveEntity> _deleteCommandOpgave;
    private readonly ICreateCommand<CreateRequestDtoProjektOpgave> _createCommandProjectOpgave;
    private readonly IGetAllOpgaverForProjekt _getAllOpgaverForProjekt;
    private readonly IGetByTitleQueryOpgave _getByTitleQueryOpgave;

    public OpgaveController(ICreateCommand<CreateRequestDtoOpgave> createCommandOpgave,
                            IGetQuery<QueryResultDtoOpgave> getQueryOpgave,
                            IGetAllQuery<QueryResultDtoOpgave> getAllQueryOpgave,
                            IUpdateCommand<UpdateRequestDtoOpgave> updateCommandOpgave,
                            IDeleteCommand<OpgaveEntity> deleteCommandOpgave,
                            ICreateCommand<CreateRequestDtoProjektOpgave> createCommand,
                            IGetAllOpgaverForProjekt getAllOpgaverForProjekt,
                            IGetByTitleQueryOpgave getByTitleQueryOpgave
                            )
    {
        _createCommandOpgave = createCommandOpgave;
        _getQueryOpgave = getQueryOpgave;
        _getAllQueryOpgave = getAllQueryOpgave;
        _updateCommandOpgave = updateCommandOpgave;
        _deleteCommandOpgave = deleteCommandOpgave;
        _createCommandProjectOpgave = createCommand;
        _getAllOpgaverForProjekt = getAllOpgaverForProjekt;
        _getByTitleQueryOpgave = getByTitleQueryOpgave;
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post([FromBody] CreateRequestDtoOpgave request)
    {
        try 
        {
            _createCommandOpgave.Create(request);

            var createdOpgave = _getByTitleQueryOpgave.GetByTitle(request.Title);

            _createCommandProjectOpgave.Create(new CreateRequestDtoProjektOpgave 
                                                        { OpgaveId = createdOpgave.Id, 
                                                          ProjektId = request.ProjektId });
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QueryResultDtoOpgave> Get(int id)
    {
        try
        {
            var result = _getQueryOpgave.Get(id);
            return Ok(result);
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
    public ActionResult<IEnumerable<QueryResultDtoOpgave>> GetAll()
    {
        try
        {
            var result = _getAllQueryOpgave.GetAll().ToList();
            return result;
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Put([FromBody] UpdateRequestDtoOpgave requestDto)
    {
        try
        {
            _updateCommandOpgave.Update(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Delete(int id)
    {
        try
        {
            _deleteCommandOpgave.Delete(id);
        }
        catch (Exception e)
        {
            BadRequest(e.Message);
        }
    }

    [HttpGet("GetAllOpgaverForProjekt/{projektId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<QueryResultDtoOpgave>> GetAllOpgaverForProjekt(int projektId)
    {
        
            var projektOpgaver = _getAllOpgaverForProjekt.GetAllOpgaverForProjekt(projektId).ToList();

            var result = new List<QueryResultDtoOpgave>();

            foreach (var opg in projektOpgaver)
            {
                result.Add(_getQueryOpgave.Get(opg.OpgaveId));
            }
            
            return result;
    }
}