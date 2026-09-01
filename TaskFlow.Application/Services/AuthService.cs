using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Interfaces.Iservices;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.Services
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;// AuthService depends on IUserRepository to access user data.
                                                         // The repository is injected through the constructor using Dependency Injection,
                                                         // so AuthService does not need to create the repository itself.

        public AuthService(IUserRepository userRepository)// The constructor receives the required IUserRepository from the DI container 
                                                          // and stores it in _userRepository so it can be used throughout the service.
        {
            _userRepository = userRepository;
        }

        public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDto> LoginAsync(LoginRequestDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
