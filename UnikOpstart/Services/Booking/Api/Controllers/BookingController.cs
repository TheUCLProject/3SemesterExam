using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Commands;
using UnikOpstart.Services.Booking.Application.Commands.Implementations.Booking;
using UnikOpstart.Services.Booking.Application.Queries;
using UnikOpstart.Services.Booking.Application.Queries.Implementations.Booking;

namespace UnikOpstart.Services.Booking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly ICreateCommand<CreateRequestDtoBooking> _create;
    private readonly IGetAllByMedarbejderIdQuery<QueryResultDtoBooking> _getAllByMedarbejderId;
    private readonly IGetQuery<QueryResultDtoBooking> _get;
    private readonly IUpdateCommand<UpdateRequestDtoBooking> _update;
    private readonly IDeleteCommand<BookingEntity> _delete;
    private readonly IGetAvailableMedarbejderQuery _getAvailableMedarbejderQuery;
    public BookingController(ICreateCommand<CreateRequestDtoBooking> create, 
                             IGetAllByMedarbejderIdQuery<QueryResultDtoBooking> getAllByMedarbejderId,
                             IGetQuery<QueryResultDtoBooking> get,
                             IUpdateCommand<UpdateRequestDtoBooking> update,
                             IDeleteCommand<BookingEntity> delete,
                             IGetAvailableMedarbejderQuery getAvailableMedarbejderQuery)
    {
        _create = create;
        _getAllByMedarbejderId = getAllByMedarbejderId;
        _get = get;
        _update = update;
        _delete = delete;
        _getAvailableMedarbejderQuery = getAvailableMedarbejderQuery;
    }

    // POST api/<UserController>
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post([FromBody] CreateRequestDtoBooking request)
    {
        try
        {
            _create.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET api/<UserController>/5
    [HttpGet("Get/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QueryResultDtoBooking> Get(int id)
    {
        try
        {
            var result = _get.Get(id);
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
    public ActionResult<IEnumerable<QueryResultDtoBooking>> GetAllByMedarbejderId(int medarbejderId)
    {
        var result = _getAllByMedarbejderId.GetAllByMedarbejderId(medarbejderId);
        return result.ToList();
    }

    [HttpPost("GetAvailableMedarbejder")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QueryResultDtoBooking> GetAvailableMedarbejder([FromBody] GetRequestDtoBooking request)
    {
        try
        {
            var result = _getAvailableMedarbejderQuery.GetAvailableMedarbejder(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    // PUT api/<UserController>/5
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] UpdateRequestDtoBooking request)
    {
        try
        {
            _update.Update(request);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    // DELETE api/<UserController>/5
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Delete(int id)
    {
        try
        {
            _delete.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
