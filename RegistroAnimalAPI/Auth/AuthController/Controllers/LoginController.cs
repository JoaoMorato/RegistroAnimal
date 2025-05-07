using AuthRepository.Models;
using AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Util;

namespace Auth.Controllers;

[AllowAnonymous]
public class LoginController : BaseAPI
{
    private readonly ILoginService loginService;

    public LoginController(ILoginService service)
    {
        loginService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Login(string user, string password)
    {
        return new JsonResult(await loginService.GetUser(user));
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        return new JsonResult(await loginService.RegisterUser(user));
    }
}
