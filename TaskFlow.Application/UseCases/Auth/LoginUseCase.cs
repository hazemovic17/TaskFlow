using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Auth
{


    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;

        public LoginUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponseDto> ExecuteAsync(LoginRequestDto loginDto)
        {
            // Login business logic will be implemented here.

            throw new NotImplementedException();
        }
    }
}
