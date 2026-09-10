using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Auth
{

    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginUseCase(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> ExecuteAsync(
            LoginRequestDto loginDto)
        {
            // Find user by email
            var user = await _userRepository
                .GetByEmailAsync(loginDto.Email);

            if (user is null)
            {
                throw new BadRequestException(
                    "Invalid email or password.");
            }


            if (user.Password != loginDto.Password)// Check password
            {
                throw new BadRequestException(
                    "Invalid email or password.");
            }


            var token = _jwtService.GenerateToken(user);


            return new AuthResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = token
            };
        }
    }
}