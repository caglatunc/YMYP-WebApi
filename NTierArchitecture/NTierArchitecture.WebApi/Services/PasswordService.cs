using System.Text;

namespace NTierArchitecture.WebApi.Services;

public static class PasswordService
{
    public static void CreatePassword(string password, out byte[] hash, out byte[] salt)
    {
     var hmac=new System.Security.Cryptography.HMACSHA512();
        salt=hmac.Key;
        hash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }   

    public static bool CheckPassword(User user, string password)
    {

    }
}
