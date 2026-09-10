using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.UseCases.Auth;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        
        return new AuthResponseDto
        {
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}