using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.DI;

namespace Util.AppService;
public class AppServices : IAppServices, IServiceScoped
{
    private readonly IConfiguration Configuration;
    private string JWT = string.Empty;
    private HttpContext? Context { get; set; } = null;

    public AppServices(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void SetHTTP(ref HttpContext http)
    {
        Context ??= http;
    }

    public string GetJWT() => JWT;
}
