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

    [HttpGet]
    public IActionResult GetDuties()
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null){
            Console.WriteLine($"tried to find the user claim and it was {user == null}");
            return Unauthorized("not authorized to see the duties");
        }
        Console.WriteLine($"obtained the user Claim correctly {user}");

        List<DutyModel> dutiesList = this._dutiesService.GetDuties(user);

        if (dutiesList != null)
        {
            return Ok(dutiesList);
        }

        return NotFound("Could not find the duties list");
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public IActionResult GetDuty(int id)
    {
        DutyModel? reqDuty = this._dutiesService.GetDuty(id);

        if (reqDuty != null)
        {
            return Ok(reqDuty);
        }

        return NotFound("Could not find a duty that matches the specified id.");
    }
    //TODO remove the allow anonoymous on all methods
    [AllowAnonymous]
    [HttpPost]
    public IActionResult AddDuty([FromBody] PostDutyModel newDuty)
    {
        string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (user == null){
            return Unauthorized("could not find the current username");
        }

        DutyModel? duty = this._dutiesService.AddDuty(newDuty, user);

        if (duty != null)
        {
            //should look up how to invoke the correct 201 code
            return Created($"Duties/{duty.DutyId}", duty);
        }
        else
        {
            return BadRequest();
        }
    }

    [AllowAnonymous]
    [HttpDelete("{id}")]
    public IActionResult deleteDuty(int id)
    {
        DutyModel? deletedDuty = this._dutiesService.DeleteDuty(id);

        if (deletedDuty != null)
        {
            return Ok();
        }
        else
        {
            return NotFound("could not find the resource");
        }
    }

    [AllowAnonymous]
    [HttpPut("{id}")]
    public IActionResult updateDuty(int id, [FromBody] PostDutyModel updatedDuty){
        var update = this._dutiesService.ReplaceDuty(id, updatedDuty);

        if (update != null){
            return StatusCode(201);
        }
        else {
            return BadRequest();
        }
    }
}
