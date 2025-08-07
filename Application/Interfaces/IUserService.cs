namespace SecureFlow.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateUserAsync(string username, string password);
        Task<string> GetUserRoleAsync(string username);
    }
}