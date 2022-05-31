using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVFilter.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_allowVueRequests")]
    public class BaseController : ControllerBase
    {
    }
}
