using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebApi.Controllers;
public class AuthController : Controller
{
    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        if(request.Name.length < 3 || string.IsNullOrWhiteSpace(request.name))
        {
            throw new ArgumentException("Name must be at least 3 characters");
        }
        if(request.LastName.length < 3 || string.IsNullOrWhiteSpace(request.LastName))
        {
            throw new ArgumentException("Last Name must be at least 3 characters");
        }
        if(request.Email.Contains("@") || string.IsNullOrWhiteSpace(request.name) && request.Email.Length < 4)
        {
            throw new ArgumentException("Geçerli bir mail adresi giriniz.");
        }
     
        if(request.Password.Length < 1 || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Password must be at least 1 characters");
        }

        byte[] passwordHash;
        byte[] passwordSalt;

        PasswordService.CreatePassword(request.Password, out passwordHash, out passwordSalt);
    }
}
