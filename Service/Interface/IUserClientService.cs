namespace Service.Interface;
public interface IUserClientService
{
    Task<string?> SearchUsersAsync(CancellationToken cancellationToken);
    Task<string?> SearchOrderAsync(CancellationToken cancellationToken);
    Task<string?> SearchRoleAsync(CancellationToken cancellationToken);
}