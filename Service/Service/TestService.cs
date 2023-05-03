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

        var taskOrderRes = _userClientService
                               .SearchOrderAsync(cancellationToken);

        var tasUserRes = _userClientService
                               .SearchUsersAsync(cancellationToken);

        var taskRoleRes = _userClientService
                                .SearchRoleAsync(cancellationToken);

        var res = await Task.WhenAll(taskOrderRes, tasUserRes, taskRoleRes);

        watch.Stop();
        _logger.LogInformation($"service result time:{res}");

        File.AppendAllText("Result.txt", String.Join("",res));

    }
}
