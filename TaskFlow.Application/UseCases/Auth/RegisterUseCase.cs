using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.UseCases.Auth;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public RegisterUseCase(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> ExecuteAsync(
        RegisterRequestDto registerDto)
    {
        // Check if the email already exists
        var existingUser = await _userRepository
            .GetByEmailAsync(registerDto.Email);

        if (existingUser is not null)
        {
            throw new BadRequestException(
                "Email is already registered.");
        }

        // Create the user entity
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = registerDto.Name,
            Email = registerDto.Email,
            Password = registerDto.Password,
            Role = UserRole.Member
        };

        await _userRepository.AddAsync(user);

        // Generate JWT token for the newly registered user
        var token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role.ToString(),
            Token = token
        };
    }
}