using AuthRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService;
public interface ILoginService
{
    Task<User> GetUser(string user);
    Task<User> RegisterUser(User user);
}
