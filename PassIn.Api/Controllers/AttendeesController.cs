﻿using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAll;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendeesController : ControllerBase
{
    [HttpGet]
    [Route("events/{eventId}/attendees")]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseAllAttendeesByEventIdJson), StatusCodes.Status200OK)]
    public IActionResult GetAll([FromRoute] Guid eventId)
    {
        var useCase = new GetAllAttendeesByEventIdUseCase();
        var response = useCase.Execute(eventId);
        return Ok(response);
    }
}
