using Microsoft.Extensions.Logging;
using Service.Interface;
using System.Diagnostics;

namespace Service.Service;
public class TestService : ITestService
{
    // Services
    private readonly IUserClientService _userClientService;
    private readonly ILogger<TestService> _logger;

    //ctor
    public TestService(IUserClientService userClientService,
                       ILogger<TestService> logger)
    {
        _userClientService = userClientService;
        _logger = logger;
    }

    //Implementations
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var watch = Stopwatch.StartNew();

        var orderResult = await _userClientService
                               .SearchOrderAsync(cancellationToken);
        watch.Stop();
        _logger.LogInformation($" SearchOrderAsync service result time:{watch}");
        File.AppendAllText("Result.txt", orderResult);
        watch.Reset();

        watch.Start();
        var userResult = await _userClientService
                               .SearchUsersAsync(cancellationToken);
        watch.Stop();
        _logger.LogInformation($" SearchUsersAsync service result time:{watch}");
        File.AppendAllText("Result.txt", userResult);
        watch.Reset();


        watch.Start();
        var rolerResult = await _userClientService
                                .SearchRoleAsync(cancellationToken);
        watch.Stop();
        _logger.LogInformation($" SearchRoleAsync service result time:{watch}");
        File.AppendAllText("Result.txt", rolerResult);
        watch.Reset();

    }
}
