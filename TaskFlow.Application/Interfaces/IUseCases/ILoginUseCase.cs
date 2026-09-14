using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;

namespace TaskFlow.Application.Interfaces.IUseCases
{
    public interface ILoginUseCase
    {
        Task<AuthResponseDto> ExecuteAsync(
            LoginRequestDto loginDto);
    }
}
