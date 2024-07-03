using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection;

[ApiController]
[Route("api/[controller]")]
public class LifeTimeController : ControllerBase
{
    private readonly IdGenerator _idGenerator;

    public LifeTimeController(IdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }
    [HttpGet("lifetime")]
    [ServiceFilter(typeof(LifeTimeIndicator))]
    public IActionResult GetId()
    {
        var id = _idGenerator.Id;
        return Ok(id);
    }
}