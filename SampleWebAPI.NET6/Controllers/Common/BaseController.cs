using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebAPI.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {

    }
}