using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Interfaces.IUseCases;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IRegisterUseCase _registerUseCase;
    private readonly ILoginUseCase _loginUseCase;

    public AuthController(
        IRegisterUseCase registerUseCase,
        ILoginUseCase loginUseCase)
    {
        _registerUseCase = registerUseCase;
        _loginUseCase = loginUseCase;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequestDto registerDto)
    {
        var result = await _registerUseCase.ExecuteAsync(registerDto);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequestDto loginDto)
    {
        var result = await _loginUseCase.ExecuteAsync(loginDto);

        return Ok(result);
    }
}