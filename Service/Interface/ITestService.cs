namespace Service.Interface;
public interface ITestService
{
    Task RunAsync(CancellationToken cancellationToken);
}
