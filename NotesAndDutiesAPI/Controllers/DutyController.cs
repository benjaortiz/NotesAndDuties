using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesAndDutiesAPI.Models;

namespace NotesAndDutiesAPI.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class DutiesController : ControllerBase
{
    private IDutiesService _dutiesService;
    public DutiesController(IDutiesService service)
    {
        _dutiesService = service;
    }


    // maybe change the return value when the list is empty, to a simple empty list instead of a 404
    [HttpGet]
    public IActionResult GetDuties()
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            return Unauthorized("not authorized to see the duties");
        }

        List<DutyModel> dutiesList = this._dutiesService.GetDuties(user);

        if (dutiesList != null)
        {
            return Ok(dutiesList);
        }

        return NotFound("Could not find the duties list");
    }

    [HttpGet("{id}")]
    public IActionResult GetDuty(int id)
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            return Unauthorized("not authorized to see the duties");
        }

        try
        {
            DutyModel reqDuty = this._dutiesService.GetDuty(id, user);
            return Ok(reqDuty);
        }
        catch (NullReferenceException)
        {
            return NotFound("Could not find a duty that matches the specified id.");
        }
    }

    [HttpPost]
    public IActionResult AddDuty([FromBody] PostDutyModel newDuty)
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            return Unauthorized("could not find the current username");
        }

        DutyModel duty = this._dutiesService.AddDuty(newDuty, user);
        try
        {
            //should look up how to invoke the correct 201 code
            return Created($"Duties/{duty.DutyId}", duty);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }



    }

    [HttpDelete("{id}")]
    public IActionResult deleteDuty(int id)
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            return Unauthorized("could not find the current username");
        }

        try
        {
            DutyModel deletedDuty = this._dutiesService.DeleteDuty(id, user);
            return Ok();
        }
        catch (NullReferenceException)
        {
            return NotFound("could not find the resource");
        }

    }

    [HttpPut("{id}")]
    public IActionResult updateDuty(int id, [FromBody] PostDutyModel updatedDuty)
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            return Unauthorized("could not find the current username");
        }

        try
        {
            DutyModelDTO newDuty = new DutyModelDTO(updatedDuty, user);

            var update = this._dutiesService.ReplaceDuty(id, newDuty);
            return StatusCode(201);
        }
        catch
        {
            return BadRequest();
        }
    }
}
