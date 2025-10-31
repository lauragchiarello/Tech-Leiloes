using TechLeiloes.API.DTOs;

namespace TechLeiloes.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}