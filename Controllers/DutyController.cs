using Microsoft.AspNetCore.Mvc;

namespace NotesAndDutiesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DutiesController : ControllerBase
{
    private IDutiesService _dutiesService;
    public DutiesController(IDutiesService service){
        _dutiesService = service;
    }
}
