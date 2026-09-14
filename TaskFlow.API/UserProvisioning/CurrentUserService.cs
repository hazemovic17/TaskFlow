using System.Security.Claims;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Interfaces.UserProvisioning;
namespace TaskFlow.API.UserProvisioning;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userId = _httpContextAccessor
                .HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.Parse(userId!);
        }
    }

    public string Role
    {
        get
        {
            return _httpContextAccessor
                .HttpContext?
                .User
                .FindFirstValue(ClaimTypes.Role)!;
        }
    }
}