namespace SecureFlow.Infrastructure.Services
{
    using SecureFlow.Application.Interfaces;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        

            // DICTIONARY
            private readonly Dictionary<string, string> _users = new()
    {
        { "admin", "1234" },
        { "john", "pass123" },
        { "alice", "qwerty" },
        {"KazımErcek", "kzm1234" },
        {"AhmetÇiğiloğlu", "cgll1234"}
    };
    
   public Task<bool> ValidateUserAsync(string username, string password)
    {
        return Task.FromResult(
            _users.TryGetValue(username, out var storedPassword) && storedPassword == password
        );
    }




public Task<string> GetUserRoleAsync(string username)
{
    if (username == "admin")
        return Task.FromResult("Admin");

    return Task.FromResult("User");
}

    }
}