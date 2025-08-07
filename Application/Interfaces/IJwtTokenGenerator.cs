namespace SecureFlow.Application.Interfaces
{
    using System.Threading.Tasks;

    public interface IJwtTokenGenerator
    {
        Task<string> GenerateTokenAsync(string username, string role);


    }
}