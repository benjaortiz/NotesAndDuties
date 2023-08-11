using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesAndDutiesAPI.Models;

namespace NotesAndDutiesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DutiesController : ControllerBase
{
    private IDutiesService _dutiesService;
    public DutiesController(IDutiesService service){
        _dutiesService = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetDuties(){
        List<DutyModel> dutiesList = this._dutiesService.GetDuties();

        if (dutiesList != null){
            return Ok(dutiesList);
        }

        return NotFound("Could not find the duties list");
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public IActionResult GetDuty(int id){
        DutyModel? reqDuty = this._dutiesService.GetDuty(id);

        if (reqDuty != null){
            return Ok(reqDuty);
        }

        return NotFound("Could not find a duty that matches the specified id.");
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult AddDuty([FromBody] DutyModel newDuty){
        DutyModel? duty = this._dutiesService.AddDuty(newDuty);

        if (duty != null){
            //should look up how to invoke the correct 201 code
            return Ok();
        }

        return BadRequest();
    }
}
