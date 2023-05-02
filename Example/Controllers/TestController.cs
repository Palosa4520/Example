using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Example.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    // Services
    private readonly ITestService _testService;

    //Ctor
    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    //Implementations
    [HttpGet]
    public async Task<IActionResult> TestAsync(CancellationToken cancellationToken)
    {
        await _testService.RunAsync(cancellationToken);
        return Ok();
    }
}
