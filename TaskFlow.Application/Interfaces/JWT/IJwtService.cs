using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
