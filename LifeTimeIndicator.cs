using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;

namespace Dependency_Injection;

public class LifeTimeIndicator : IActionFilter
{
    private readonly IdGenerator _generator;
    private readonly ILogger<LifeTimeIndicator> _logger;

    public LifeTimeIndicator(IdGenerator generator, ILogger<LifeTimeIndicator> logger)
    {
        _generator = generator;
        _logger = logger;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var id = _generator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuting)} With id {id}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var id = _generator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuting)} With id {id}");
    }
}