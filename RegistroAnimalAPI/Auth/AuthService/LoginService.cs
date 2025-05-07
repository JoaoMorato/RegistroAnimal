using AuthRepository.Context;
using AuthRepository.Models;
using Util.DI;

namespace AuthService;
public class LoginService : IServiceTransient, ILoginService
{
    private readonly IAuthRepository<User> authRepository;

    public LoginService(IAuthRepository<User> authRepository)
    {
        this.authRepository = authRepository;
    }

    public async Task<User> GetUser(string user)
    {
        return await authRepository.FirstOrDefaultAsync(e => e.Name == user);
    }

    public async Task<User> RegisterUser(User user)
    {
        try
        {
            user.Id = 0;
            await authRepository.AddAsync(user);
            await authRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {

        }
        return user;
    }
}
