using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;

namespace TaskFlow.Application.Interfaces.Iservices
{

    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerDto); 

        Task<AuthResponseDto> LoginAsync(LoginRequestDto loginDto);
    }
}
