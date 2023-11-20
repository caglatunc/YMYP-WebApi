using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.WebApi.DTOs;
using NTierArchitecture.WebApi.Models;
using NTierArchitecture.WebApi.Services;

namespace NTierArchitecture.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IValidator<RegisterDto> _registerDtoValidator;

    public AuthController(IValidator<RegisterDto>  registorDtoValidator)
    {
        _registerDtoValidator = registorDtoValidator;
    }

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        #region İş Kuralları
        var validationResult = _registerDtoValidator.Validate(request);
        if(!validationResult.IsValid)
        {
          throw new ValidationException(validationResult.Errors[0].ErrorMessage);
        }
        #endregion

        #region Password Hashing
        byte[] passwordHash;
        byte[] passwordSalt;

        PasswordService.CreatePassword(request.Password, out passwordHash, out passwordSalt);
        #endregion

        #region User Nesnesi Oluşturma
        User user = new()
        {
            Name = request.Name,
            LastName = request.LastName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        #endregion

        return Ok(new {message = "Kullanıcı kaydı başarıyla tamamlandı!"});
    }
}
