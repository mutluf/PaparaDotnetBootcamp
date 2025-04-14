namespace CoffeeBreak.Services.UserServices;

public interface IUserService
{
    bool IsAuthenticated(string token);
}