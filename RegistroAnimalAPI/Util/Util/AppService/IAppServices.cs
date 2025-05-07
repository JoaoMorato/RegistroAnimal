using Microsoft.AspNetCore.Http;

namespace Util.AppService;

public interface IAppServices
{
    void SetHTTP(ref HttpContext http);
    string GetJWT();
}