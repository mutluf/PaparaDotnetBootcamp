namespace CoffeeBreak_Task3_4.Services.UserServices;

public interface IUserService
{
    bool IsAuthenticated(string token);
}