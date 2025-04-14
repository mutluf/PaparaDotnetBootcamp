namespace CoffeeBreak.Services.UserServices;

public class FakeUserService : IUserService
{
    public bool IsAuthenticated(string token)
    {
        return token == "valid-token";
    }
}