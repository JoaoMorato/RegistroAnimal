using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Util.AppService;

namespace Util;

[Route("[controller]")]
[Authorize]
public class BaseAPI : ControllerBase
{
}
