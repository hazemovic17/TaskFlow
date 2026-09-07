using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Auth
{

    public class RegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponseDto> ExecuteAsync(RegisterRequestDto registerDto)
        {
            // Registration business logic will be implemented here.

            throw new NotImplementedException();
        }
    }
}
